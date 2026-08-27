using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class ParceiroRepository : IParceiroRepository
{
    private readonly AppDbContext _context;

    public ParceiroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Parceiro> AddAsync(Parceiro parceiro)
    {
        _context.Parceiros.Add(parceiro);
        await _context.SaveChangesAsync();
        return parceiro;
    }

    public async Task<Parceiro?> GetByIdAsync(Guid id)
    {
        return await _context.Parceiros.FindAsync(id);
    }

    public async Task<PaginatedList<Parceiro>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Parceiros.CountAsync();
        var items = await _context.Parceiros
            .OrderBy(p => p.Nome)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Parceiro>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Parceiro?> UpdateAsync(Parceiro parceiro)
    {
        var existente = await _context.Parceiros.FindAsync(parceiro.Id);
        if (existente is null)
        {
            return null;
        }

        existente.Nome = parceiro.Nome;
        existente.Tipo = parceiro.Tipo;
        existente.Telefone = parceiro.Telefone;
        existente.Email = parceiro.Email;
        existente.PercentualComissao = parceiro.PercentualComissao;
        existente.AtualizadoPor = parceiro.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Parceiros.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Parceiros.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
