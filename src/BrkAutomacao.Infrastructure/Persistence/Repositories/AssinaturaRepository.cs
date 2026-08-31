using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class AssinaturaRepository : IAssinaturaRepository
{
    private readonly AppDbContext _context;

    public AssinaturaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Assinatura> AddAsync(Assinatura assinatura)
    {
        _context.Assinaturas.Add(assinatura);
        await _context.SaveChangesAsync();
        return assinatura;
    }

    public async Task<Assinatura?> GetByIdAsync(Guid id)
    {
        return await _context.Assinaturas.FindAsync(id);
    }

    public async Task<PaginatedList<Assinatura>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Assinaturas.CountAsync();
        var items = await _context.Assinaturas
            .OrderByDescending(a => a.DataInicio)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Assinatura>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Assinatura?> UpdateAsync(Assinatura assinatura)
    {
        var existente = await _context.Assinaturas.FindAsync(assinatura.Id);
        if (existente is null)
        {
            return null;
        }

        existente.ClienteId = assinatura.ClienteId;
        existente.VendaId = assinatura.VendaId;
        existente.PlanoId = assinatura.PlanoId;
        existente.ValorMensal = assinatura.ValorMensal;
        existente.DiaCobranca = assinatura.DiaCobranca;
        existente.Status = assinatura.Status;
        existente.DataInicio = assinatura.DataInicio;
        existente.DataFim = assinatura.DataFim;
        existente.AtualizadoPor = assinatura.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Assinaturas.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Assinaturas.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
