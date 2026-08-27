using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IComissaoRepository
{
    Task<Comissao> AddAsync(Comissao comissao);
    Task<Comissao?> GetByIdAsync(Guid id);
    Task<PaginatedList<Comissao>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Comissao?> UpdateAsync(Comissao comissao);
    Task<bool> DeleteAsync(Guid id);
}
