using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreatePlanoAssinaturaCommand;

public class CreatePlanoAssinaturaCommandHandler : IRequestHandler<CreatePlanoAssinaturaCommand, ResponseBase<PlanoAssinatura>>
{
    private readonly IPlanoAssinaturaRepository _planoAssinaturaRepository;

    public CreatePlanoAssinaturaCommandHandler(IPlanoAssinaturaRepository planoAssinaturaRepository)
    {
        _planoAssinaturaRepository = planoAssinaturaRepository;
    }

    public async Task<ResponseBase<PlanoAssinatura>> Handle(CreatePlanoAssinaturaCommand request, CancellationToken cancellationToken)
    {
        var plano = new PlanoAssinatura
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            ValorMensal = request.ValorMensal,
            Ativo = request.Ativo,
            CriadoEm = DateTimeOffset.UtcNow,
            AtualizadoEm = DateTimeOffset.UtcNow,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _planoAssinaturaRepository.AddAsync(plano);

        return new ResponseBase<PlanoAssinatura> { Data = criado, Message = "Plano de assinatura criado com sucesso." };
    }
}
