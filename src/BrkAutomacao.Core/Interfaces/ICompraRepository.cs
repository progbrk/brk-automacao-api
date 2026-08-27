using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface ICompraRepository
{
    Task<Compra> AddAsync(Compra compra);
    Task<Compra?> GetByIdAsync(Guid id);
    Task<PaginatedList<Compra>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Compra?> UpdateAsync(Compra compra);
    Task<bool> DeleteAsync(Guid id);
}
