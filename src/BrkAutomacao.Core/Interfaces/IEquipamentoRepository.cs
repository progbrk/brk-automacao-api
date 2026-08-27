using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;

namespace BrkAutomacao.Core.Interfaces;

public interface IEquipamentoRepository
{
    Task<Equipamento> AddAsync(Equipamento equipamento);
    Task<Equipamento?> GetByIdAsync(Guid id);
    Task<PaginatedList<Equipamento>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<Equipamento?> UpdateAsync(Equipamento equipamento);
    Task<bool> DeleteAsync(Guid id);
}
