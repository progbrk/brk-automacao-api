using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly AppDbContext _context;

    public FornecedorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Fornecedor> AddAsync(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
        await _context.SaveChangesAsync();
        return fornecedor;
    }

    public async Task<Fornecedor?> GetByIdAsync(Guid id)
    {
        return await _context.Fornecedores.FindAsync(id);
    }

    public async Task<PaginatedList<Fornecedor>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Fornecedores.CountAsync();
        var items = await _context.Fornecedores
            .OrderBy(f => f.Nome)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Fornecedor>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Fornecedor?> UpdateAsync(Fornecedor fornecedor)
    {
        var existente = await _context.Fornecedores.FindAsync(fornecedor.Id);
        if (existente is null)
        {
            return null;
        }

        existente.Nome = fornecedor.Nome;
        existente.Contato = fornecedor.Contato;
        existente.Telefone = fornecedor.Telefone;
        existente.Email = fornecedor.Email;
        existente.AtualizadoPor = fornecedor.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Fornecedores.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Fornecedores.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
