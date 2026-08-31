using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly AppDbContext _context;

    public VendaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Venda> AddAsync(Venda venda)
    {
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
        return venda;
    }

    public async Task<Venda?> GetByIdAsync(Guid id)
    {
        return await _context.Vendas.FindAsync(id);
    }

    public async Task<PaginatedList<Venda>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Vendas.CountAsync();
        var items = await _context.Vendas
            .OrderByDescending(v => v.DataVenda)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Venda>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Venda?> UpdateAsync(Venda venda)
    {
        var existente = await _context.Vendas.FindAsync(venda.Id);
        if (existente is null)
        {
            return null;
        }

        existente.ClienteId = venda.ClienteId;
        existente.ParceiroId = venda.ParceiroId;
        existente.Descricao = venda.Descricao;
        existente.Valor = venda.Valor;
        existente.Status = venda.Status;
        existente.DataVenda = venda.DataVenda;
        existente.AtualizadoPor = venda.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Vendas.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Vendas.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
