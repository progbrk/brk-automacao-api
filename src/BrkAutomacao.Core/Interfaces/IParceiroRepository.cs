using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IParceiroRepository
{
    Task<Parceiro> AddAsync(Parceiro parceiro);
    Task<Parceiro?> GetByIdAsync(Guid id);
    Task<PaginatedList<Parceiro>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Parceiro?> UpdateAsync(Parceiro parceiro);
    Task<bool> DeleteAsync(Guid id);
}
