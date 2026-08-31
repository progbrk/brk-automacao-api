using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class PlanoAssinaturaRepository : IPlanoAssinaturaRepository
{
    private readonly AppDbContext _context;

    public PlanoAssinaturaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PlanoAssinatura> AddAsync(PlanoAssinatura plano)
    {
        _context.PlanosAssinatura.Add(plano);
        await _context.SaveChangesAsync();
        return plano;
    }

    public async Task<PlanoAssinatura?> GetByIdAsync(Guid id)
    {
        return await _context.PlanosAssinatura.FindAsync(id);
    }

    public async Task<PaginatedList<PlanoAssinatura>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.PlanosAssinatura.CountAsync();
        var items = await _context.PlanosAssinatura
            .OrderBy(p => p.Nome)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<PlanoAssinatura>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<PlanoAssinatura?> UpdateAsync(PlanoAssinatura plano)
    {
        var existente = await _context.PlanosAssinatura.FindAsync(plano.Id);
        if (existente is null)
        {
            return null;
        }

        existente.Nome = plano.Nome;
        existente.Descricao = plano.Descricao;
        existente.ValorMensal = plano.ValorMensal;
        existente.Ativo = plano.Ativo;
        existente.AtualizadoPor = plano.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.PlanosAssinatura.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.PlanosAssinatura.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
