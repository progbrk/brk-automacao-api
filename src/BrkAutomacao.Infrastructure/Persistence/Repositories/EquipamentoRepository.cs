using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class EquipamentoRepository : IEquipamentoRepository
{
    private readonly AppDbContext _context;

    public EquipamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Equipamento> AddAsync(Equipamento equipamento)
    {
        _context.Equipamentos.Add(equipamento);
        await _context.SaveChangesAsync();
        return equipamento;
    }

    public async Task<Equipamento?> GetByIdAsync(Guid id)
    {
        return await _context.Equipamentos.FindAsync(id);
    }

    public async Task<PaginatedList<Equipamento>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Equipamentos.CountAsync();
        var items = await _context.Equipamentos
            .OrderByDescending(e => e.CriadoEm)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Equipamento>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Equipamento?> UpdateAsync(Equipamento equipamento)
    {
        var existente = await _context.Equipamentos.FindAsync(equipamento.Id);
        if (existente is null)
        {
            return null;
        }

        existente.ClienteId = equipamento.ClienteId;
        existente.VendaId = equipamento.VendaId;
        existente.TipoDispositivo = equipamento.TipoDispositivo;
        existente.Identificador = equipamento.Identificador;
        existente.IpVpn = equipamento.IpVpn;
        existente.Status = equipamento.Status;
        existente.DataInstalacao = equipamento.DataInstalacao;
        existente.AtualizadoEm = DateTimeOffset.UtcNow;
        existente.AtualizadoPor = equipamento.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Equipamentos.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Equipamentos.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
