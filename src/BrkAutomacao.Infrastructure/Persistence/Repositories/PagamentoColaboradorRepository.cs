using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class PagamentoColaboradorRepository : IPagamentoColaboradorRepository
{
    private readonly AppDbContext _context;

    public PagamentoColaboradorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagamentoColaborador> AddAsync(PagamentoColaborador pagamento)
    {
        _context.PagamentosColaboradores.Add(pagamento);
        await _context.SaveChangesAsync();
        return pagamento;
    }

    public async Task<PagamentoColaborador?> GetByIdAsync(Guid id)
    {
        return await _context.PagamentosColaboradores.FindAsync(id);
    }

    public async Task<PaginatedList<PagamentoColaborador>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.PagamentosColaboradores.CountAsync();
        var items = await _context.PagamentosColaboradores
            .OrderByDescending(p => p.CriadoEm)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<PagamentoColaborador>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<PagamentoColaborador?> UpdateAsync(PagamentoColaborador pagamento)
    {
        var existente = await _context.PagamentosColaboradores.FindAsync(pagamento.Id);
        if (existente is null)
        {
            return null;
        }

        existente.ColaboradorId = pagamento.ColaboradorId;
        existente.VendaServicoId = pagamento.VendaServicoId;
        existente.Valor = pagamento.Valor;
        existente.Status = pagamento.Status;
        existente.DataPagamento = pagamento.DataPagamento;
        existente.AtualizadoPor = pagamento.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.PagamentosColaboradores.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.PagamentosColaboradores.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
