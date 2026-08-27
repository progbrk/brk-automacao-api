using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Produto> AddAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto?> GetByIdAsync(Guid id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task<PaginatedList<Produto>> GetAllPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalCount = await _context.Produtos.CountAsync();
        var items = await _context.Produtos
            .OrderBy(p => p.Nome)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Produto>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<Produto?> UpdateAsync(Produto produto)
    {
        var existente = await _context.Produtos.FindAsync(produto.Id);
        if (existente is null)
        {
            return null;
        }

        existente.Nome = produto.Nome;
        existente.Descricao = produto.Descricao;
        existente.Tipo = produto.Tipo;
        existente.PrecoVenda = produto.PrecoVenda;
        existente.CustoBase = produto.CustoBase;
        existente.Ativo = produto.Ativo;
        existente.AtualizadoPor = produto.AtualizadoPor;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existente = await _context.Produtos.FindAsync(id);
        if (existente is null)
        {
            return false;
        }

        _context.Produtos.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
