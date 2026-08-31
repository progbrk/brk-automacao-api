using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class ColaboradorRepository : IColaboradorRepository
{
    private readonly AppDbContext _context;

    public ColaboradorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Colaborador> AddAsync(Colaborador colaborador)
    {
        _context.Colaboradores.Add(colaborador);
        await _context.SaveChangesAsync();
        return colaborador;
    }

    public async Task<Colaborador?> GetByIdAsync(Guid id)
    {
        return await _context.Colaboradores.FindAsync(id);
    }

    public async Task<PaginatedList<Colaborador>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Colaboradores.CountAsync();
        var items = await _context.Colaboradores
            .OrderBy(c => c.Nome)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Colaborador>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Colaborador?> UpdateAsync(Colaborador colaborador)
    {
        var existente = await _context.Colaboradores.FindAsync(colaborador.Id);
        if (existente is null)
        {
            return null;
        }

        existente.Nome = colaborador.Nome;
        existente.Cargo = colaborador.Cargo;
        existente.Telefone = colaborador.Telefone;
        existente.Email = colaborador.Email;
        existente.Ativo = colaborador.Ativo;
        existente.AtualizadoPor = colaborador.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Colaboradores.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Colaboradores.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
