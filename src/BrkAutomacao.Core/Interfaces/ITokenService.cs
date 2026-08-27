using BrkAutomacao.Core.Entities;

namespace BrkAutomacao.Core.Interfaces;

public interface ITokenService
{
    string GerarToken(Usuario usuario);
}
