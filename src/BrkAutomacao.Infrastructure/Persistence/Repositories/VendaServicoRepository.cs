using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class VendaServicoRepository : IVendaServicoRepository
{
    private readonly AppDbContext _context;

    public VendaServicoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VendaServico> AddAsync(VendaServico item)
    {
        _context.VendaServicos.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<VendaServico?> GetByIdAsync(Guid id)
    {
        return await _context.VendaServicos.FindAsync(id);
    }

    public async Task<PaginatedList<VendaServico>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.VendaServicos.CountAsync();
        var items = await _context.VendaServicos
            .OrderByDescending(i => i.CriadoEm)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<VendaServico>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<List<VendaServico>> GetByVendaIdAsync(Guid vendaId)
    {
        return await _context.VendaServicos
            .Where(i => i.VendaId == vendaId)
            .OrderBy(i => i.CriadoEm)
            .ToListAsync();
    }

    public async Task<VendaServico?> UpdateAsync(VendaServico item)
    {
        var existente = await _context.VendaServicos.FindAsync(item.Id);
        if (existente is null)
        {
            return null;
        }

        existente.VendaId = item.VendaId;
        existente.ServicoId = item.ServicoId;
        existente.Quantidade = item.Quantidade;
        existente.PrecoUnitario = item.PrecoUnitario;
        existente.AtualizadoEm = DateTimeOffset.UtcNow;
        existente.AtualizadoPor = item.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.VendaServicos.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.VendaServicos.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
