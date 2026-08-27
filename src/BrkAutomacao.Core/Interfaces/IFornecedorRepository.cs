using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IFornecedorRepository
{
    Task<Fornecedor> AddAsync(Fornecedor fornecedor);
    Task<Fornecedor?> GetByIdAsync(Guid id);
    Task<PaginatedList<Fornecedor>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Fornecedor?> UpdateAsync(Fornecedor fornecedor);
    Task<bool> DeleteAsync(Guid id);
}
