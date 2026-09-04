using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class ServicoRepository : IServicoRepository
{
    private readonly AppDbContext _context;

    public ServicoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Servico> AddAsync(Servico servico)
    {
        _context.Servicos.Add(servico);
        await _context.SaveChangesAsync();
        return servico;
    }

    public async Task<Servico?> GetByIdAsync(Guid id)
    {
        return await _context.Servicos.FindAsync(id);
    }

    public async Task<PaginatedList<Servico>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Servicos.CountAsync();
        var items = await _context.Servicos
            .OrderBy(s => s.Nome)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Servico>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Servico?> UpdateAsync(Servico servico)
    {
        var existente = await _context.Servicos.FindAsync(servico.Id);
        if (existente is null)
        {
            return null;
        }

        existente.Nome = servico.Nome;
        existente.Descricao = servico.Descricao;
        existente.Preco = servico.Preco;
        existente.Ativo = servico.Ativo;
        existente.AtualizadoEm = DateTimeOffset.UtcNow;
        existente.AtualizadoPor = servico.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Servicos.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Servicos.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
