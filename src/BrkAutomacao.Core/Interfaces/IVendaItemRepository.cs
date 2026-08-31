using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IVendaItemRepository
{
    Task<VendaItem> AddAsync(VendaItem item);
    Task<VendaItem?> GetByIdAsync(Guid id);
    Task<PaginatedList<VendaItem>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<List<VendaItem>> GetByVendaIdAsync(Guid vendaId);
    Task<VendaItem?> UpdateAsync(VendaItem item);
    Task<bool> DeleteAsync(Guid id);
}
