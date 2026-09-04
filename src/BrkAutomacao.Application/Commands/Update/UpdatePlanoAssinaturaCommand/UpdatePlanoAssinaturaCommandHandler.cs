using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdatePlanoAssinaturaCommand;

public class UpdatePlanoAssinaturaCommandHandler : IRequestHandler<UpdatePlanoAssinaturaCommand, ResponseBase<PlanoAssinatura>>
{
    private readonly IPlanoAssinaturaRepository _planoAssinaturaRepository;

    public UpdatePlanoAssinaturaCommandHandler(IPlanoAssinaturaRepository planoAssinaturaRepository)
    {
        _planoAssinaturaRepository = planoAssinaturaRepository;
    }

    public async Task<ResponseBase<PlanoAssinatura>> Handle(UpdatePlanoAssinaturaCommand request, CancellationToken cancellationToken)
    {
        var plano = new PlanoAssinatura
        {
            Id = request.Id,
            Nome = request.Nome,
            Descricao = request.Descricao,
            ValorMensal = request.ValorMensal,
            Ativo = request.Ativo,
            AtualizadoEm = DateTimeOffset.UtcNow,
            AtualizadoPor = request.UsuarioId,
        };

        var atualizado = await _planoAssinaturaRepository.UpdateAsync(plano);
        if (atualizado is null)
        {
            return new ResponseBase<PlanoAssinatura> { Success = false, Message = "Plano de assinatura não encontrado." };
        }

        return new ResponseBase<PlanoAssinatura> { Data = atualizado, Message = "Plano de assinatura atualizado com sucesso." };
    }
}
