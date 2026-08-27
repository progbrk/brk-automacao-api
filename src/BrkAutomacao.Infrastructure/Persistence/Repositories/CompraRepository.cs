using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class CompraRepository : ICompraRepository
{
    private readonly AppDbContext _context;

    public CompraRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Compra> AddAsync(Compra compra)
    {
        _context.Compras.Add(compra);
        await _context.SaveChangesAsync();
        return compra;
    }

    public async Task<Compra?> GetByIdAsync(Guid id)
    {
        return await _context.Compras.FindAsync(id);
    }

    public async Task<PaginatedList<Compra>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Compras.CountAsync();
        var items = await _context.Compras
            .OrderByDescending(c => c.DataCompra)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Compra>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Compra?> UpdateAsync(Compra compra)
    {
        var existente = await _context.Compras.FindAsync(compra.Id);
        if (existente is null)
        {
            return null;
        }

        existente.FornecedorId = compra.FornecedorId;
        existente.VendaId = compra.VendaId;
        existente.Item = compra.Item;
        existente.Quantidade = compra.Quantidade;
        existente.ValorUnitario = compra.ValorUnitario;
        existente.Frete = compra.Frete;
        existente.Imposto = compra.Imposto;
        existente.DataCompra = compra.DataCompra;
        existente.AtualizadoPor = compra.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Compras.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Compras.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
