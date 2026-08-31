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
        venda.Valor = 0;
        return venda;
    }

    public async Task<Venda?> GetByIdAsync(Guid id)
    {
        var venda = await _context.Vendas.FindAsync(id);
        if (venda is null)
        {
            return null;
        }

        venda.Valor = await CalcularValorAsync(id);
        return venda;
    }

    public async Task<PaginatedList<Venda>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Vendas.CountAsync();
        var items = await _context.Vendas
            .OrderByDescending(v => v.DataVenda)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        foreach (var venda in items)
        {
            venda.Valor = await CalcularValorAsync(venda.Id);
        }

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
        existente.Status = venda.Status;
        existente.DataVenda = venda.DataVenda;
        existente.AtualizadoPor = venda.AtualizadoPor;

        await _context.SaveChangesAsync();
        existente.Valor = await CalcularValorAsync(existente.Id);
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

    private async Task<decimal> CalcularValorAsync(Guid vendaId)
    {
        var totalItens = await _context.VendaItens
            .Where(i => i.VendaId == vendaId)
            .SumAsync(i => (decimal?)i.ValorTotal) ?? 0;

        var totalServicos = await _context.VendaServicos
            .Where(s => s.VendaId == vendaId)
            .SumAsync(s => (decimal?)s.ValorTotal) ?? 0;

        return totalItens + totalServicos;
    }
}
