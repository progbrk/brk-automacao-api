using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IPlanoAssinaturaRepository
{
    Task<PlanoAssinatura> AddAsync(PlanoAssinatura plano);
    Task<PlanoAssinatura?> GetByIdAsync(Guid id);
    Task<PaginatedList<PlanoAssinatura>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<PlanoAssinatura?> UpdateAsync(PlanoAssinatura plano);
    Task<bool> DeleteAsync(Guid id);
}
