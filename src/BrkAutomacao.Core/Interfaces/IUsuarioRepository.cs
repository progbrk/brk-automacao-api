using BrkAutomacao.Core.Entities;

namespace BrkAutomacao.Core.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByEmailAsync(string email);
}
