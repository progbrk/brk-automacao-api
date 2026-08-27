using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrkAutomacao.Application.Commands.Create.CreateLoginCommand;

public class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, ResponseBase<string>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITokenService _tokenService;
    private readonly ILogger<CreateLoginCommandHandler> _logger;

    public CreateLoginCommandHandler(
        IUsuarioRepository usuarioRepository,
        ITokenService tokenService,
        ILogger<CreateLoginCommandHandler> logger)
    {
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
        _logger = logger;
    }

    public async Task<ResponseBase<string>> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
    {
        var response = new ResponseBase<string>();

        var usuario = await _usuarioRepository.GetByLoginAsync(request.Usuario);
        if (usuario is null || usuario.SenhaHash is null ||
            !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
        {
            _logger.LogWarning("Tentativa de login inválida para {Usuario}", request.Usuario);
            response.Success = false;
            response.Message = "Usuário ou senha inválidos.";
            return response;
        }

        response.Data = _tokenService.GerarToken(usuario);
        response.Message = "Login realizado com sucesso.";

        _logger.LogInformation("Login bem-sucedido para {Usuario}", request.Usuario);
        return response;
    }
}
