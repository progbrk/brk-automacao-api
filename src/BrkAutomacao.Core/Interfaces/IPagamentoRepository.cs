using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IPagamentoRepository
{
    Task<Pagamento> AddAsync(Pagamento pagamento);
    Task<Pagamento?> GetByIdAsync(Guid id);
    Task<PaginatedList<Pagamento>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Pagamento?> UpdateAsync(Pagamento pagamento);
    Task<bool> DeleteAsync(Guid id);
}
