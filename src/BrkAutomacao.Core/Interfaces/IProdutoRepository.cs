using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IProdutoRepository
{
    Task<Produto> AddAsync(Produto produto);
    Task<Produto?> GetByIdAsync(Guid id);
    Task<PaginatedList<Produto>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Produto?> UpdateAsync(Produto produto);
    Task<bool> DeleteAsync(Guid id);
}
