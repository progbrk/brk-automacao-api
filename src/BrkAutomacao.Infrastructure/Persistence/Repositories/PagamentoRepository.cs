using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class PagamentoRepository : IPagamentoRepository
{
    private readonly AppDbContext _context;

    public PagamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pagamento> AddAsync(Pagamento pagamento)
    {
        _context.Pagamentos.Add(pagamento);
        await _context.SaveChangesAsync();
        return pagamento;
    }

    public async Task<Pagamento?> GetByIdAsync(Guid id)
    {
        return await _context.Pagamentos.FindAsync(id);
    }

    public async Task<PaginatedList<Pagamento>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Pagamentos.CountAsync();
        var items = await _context.Pagamentos
            .OrderByDescending(p => p.CriadoEm)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Pagamento>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Pagamento?> UpdateAsync(Pagamento pagamento)
    {
        var existente = await _context.Pagamentos.FindAsync(pagamento.Id);
        if (existente is null)
        {
            return null;
        }

        existente.ClienteId = pagamento.ClienteId;
        existente.VendaId = pagamento.VendaId;
        existente.AssinaturaId = pagamento.AssinaturaId;
        existente.Valor = pagamento.Valor;
        existente.FormaPagamento = pagamento.FormaPagamento;
        existente.Status = pagamento.Status;
        existente.DataPagamento = pagamento.DataPagamento;
        existente.AtualizadoEm = DateTimeOffset.UtcNow;
        existente.AtualizadoPor = pagamento.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Pagamentos.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Pagamentos.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
