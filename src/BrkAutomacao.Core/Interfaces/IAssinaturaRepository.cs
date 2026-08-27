using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IAssinaturaRepository
{
    Task<Assinatura> AddAsync(Assinatura assinatura);
    Task<Assinatura?> GetByIdAsync(Guid id);
    Task<PaginatedList<Assinatura>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Assinatura?> UpdateAsync(Assinatura assinatura);
    Task<bool> DeleteAsync(Guid id);
}
