using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IVendaServicoRepository
{
    Task<VendaServico> AddAsync(VendaServico item);
    Task<VendaServico?> GetByIdAsync(Guid id);
    Task<PaginatedList<VendaServico>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<List<VendaServico>> GetByVendaIdAsync(Guid vendaId);
    Task<VendaServico?> UpdateAsync(VendaServico item);
    Task<bool> DeleteAsync(Guid id);
}
