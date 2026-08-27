namespace BrkAutomacao.Core.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
