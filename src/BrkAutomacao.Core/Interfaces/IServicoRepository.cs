using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IServicoRepository
{
    Task<Servico> AddAsync(Servico servico);
    Task<Servico?> GetByIdAsync(Guid id);
    Task<PaginatedList<Servico>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Servico?> UpdateAsync(Servico servico);
    Task<bool> DeleteAsync(Guid id);
}
