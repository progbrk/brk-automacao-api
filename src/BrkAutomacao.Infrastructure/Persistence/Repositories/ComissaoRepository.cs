using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class ComissaoRepository : IComissaoRepository
{
    private readonly AppDbContext _context;

    public ComissaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Comissao> AddAsync(Comissao comissao)
    {
        _context.Comissoes.Add(comissao);
        await _context.SaveChangesAsync();
        return comissao;
    }

    public async Task<Comissao?> GetByIdAsync(Guid id)
    {
        return await _context.Comissoes.FindAsync(id);
    }

    public async Task<PaginatedList<Comissao>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Comissoes.CountAsync();
        var items = await _context.Comissoes
            .OrderByDescending(c => c.CriadoEm)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Comissao>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Comissao?> UpdateAsync(Comissao comissao)
    {
        var existente = await _context.Comissoes.FindAsync(comissao.Id);
        if (existente is null)
        {
            return null;
        }

        existente.ParceiroId = comissao.ParceiroId;
        existente.VendaId = comissao.VendaId;
        existente.Valor = comissao.Valor;
        existente.Status = comissao.Status;
        existente.DataPagamento = comissao.DataPagamento;
        existente.AtualizadoEm = DateTimeOffset.UtcNow;
        existente.AtualizadoPor = comissao.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Comissoes.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Comissoes.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
