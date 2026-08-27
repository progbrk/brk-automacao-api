using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IVendaRepository
{
    Task<Venda> AddAsync(Venda venda);
    Task<Venda?> GetByIdAsync(Guid id);
    Task<PaginatedList<Venda>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Venda?> UpdateAsync(Venda venda);
    Task<bool> DeleteAsync(Guid id);
}
