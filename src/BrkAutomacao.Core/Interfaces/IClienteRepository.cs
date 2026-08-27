using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IClienteRepository
{
    Task<Cliente> AddAsync(Cliente cliente);
    Task<Cliente?> GetByIdAsync(Guid id);
    Task<PaginatedList<Cliente>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Cliente?> UpdateAsync(Cliente cliente);
    Task<bool> DeleteAsync(Guid id);
}
