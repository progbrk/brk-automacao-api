using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> AddAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente?> GetByIdAsync(Guid id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<PaginatedList<Cliente>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Clientes.CountAsync();
        var items = await _context.Clientes
            .OrderBy(c => c.Nome)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Cliente>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Cliente?> UpdateAsync(Cliente cliente)
    {
        var existente = await _context.Clientes.FindAsync(cliente.Id);
        if (existente is null)
        {
            return null;
        }

        existente.Nome = cliente.Nome;
        existente.CpfCnpj = cliente.CpfCnpj;
        existente.Telefone = cliente.Telefone;
        existente.Email = cliente.Email;
        existente.Endereco = cliente.Endereco;
        existente.Cidade = cliente.Cidade;
        existente.Estado = cliente.Estado;
        existente.Cep = cliente.Cep;
        existente.Observacoes = cliente.Observacoes;
        existente.AtualizadoEm = DateTimeOffset.UtcNow;
        existente.AtualizadoPor = cliente.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Clientes.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Clientes.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
