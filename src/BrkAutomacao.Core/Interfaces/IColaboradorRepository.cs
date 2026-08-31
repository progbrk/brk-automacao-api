using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IColaboradorRepository
{
    Task<Colaborador> AddAsync(Colaborador colaborador);
    Task<Colaborador?> GetByIdAsync(Guid id);
    Task<PaginatedList<Colaborador>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Colaborador?> UpdateAsync(Colaborador colaborador);
    Task<bool> DeleteAsync(Guid id);
}
