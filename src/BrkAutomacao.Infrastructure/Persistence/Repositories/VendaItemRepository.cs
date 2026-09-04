using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class VendaItemRepository : IVendaItemRepository
{
    private readonly AppDbContext _context;

    public VendaItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VendaItem> AddAsync(VendaItem item)
    {
        _context.VendaItens.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<VendaItem?> GetByIdAsync(Guid id)
    {
        return await _context.VendaItens.FindAsync(id);
    }

    public async Task<PaginatedList<VendaItem>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.VendaItens.CountAsync();
        var items = await _context.VendaItens
            .OrderByDescending(i => i.CriadoEm)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<VendaItem>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<List<VendaItem>> GetByVendaIdAsync(Guid vendaId)
    {
        return await _context.VendaItens
            .Where(i => i.VendaId == vendaId)
            .OrderBy(i => i.CriadoEm)
            .ToListAsync();
    }

    public async Task<VendaItem?> UpdateAsync(VendaItem item)
    {
        var existente = await _context.VendaItens.FindAsync(item.Id);
        if (existente is null)
        {
            return null;
        }

        existente.VendaId = item.VendaId;
        existente.ProdutoId = item.ProdutoId;
        existente.Quantidade = item.Quantidade;
        existente.PrecoUnitario = item.PrecoUnitario;
        existente.AtualizadoEm = DateTimeOffset.UtcNow;
        existente.AtualizadoPor = item.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.VendaItens.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.VendaItens.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
