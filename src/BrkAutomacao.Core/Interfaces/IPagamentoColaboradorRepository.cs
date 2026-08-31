using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IPagamentoColaboradorRepository
{
    Task<PagamentoColaborador> AddAsync(PagamentoColaborador pagamento);
    Task<PagamentoColaborador?> GetByIdAsync(Guid id);
    Task<PaginatedList<PagamentoColaborador>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<PagamentoColaborador?> UpdateAsync(PagamentoColaborador pagamento);
    Task<bool> DeleteAsync(Guid id);
}
