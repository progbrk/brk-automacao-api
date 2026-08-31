using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateAssinaturaCommand;

public class UpdateAssinaturaCommandHandler : IRequestHandler<UpdateAssinaturaCommand, ResponseBase<Assinatura>>
{
    private readonly IAssinaturaRepository _assinaturaRepository;

    public UpdateAssinaturaCommandHandler(IAssinaturaRepository assinaturaRepository)
    {
        _assinaturaRepository = assinaturaRepository;
    }

    public async Task<ResponseBase<Assinatura>> Handle(UpdateAssinaturaCommand request, CancellationToken cancellationToken)
    {
        var assinatura = new Assinatura
        {
            Id = request.Id,
            ClienteId = request.ClienteId,
            VendaId = request.VendaId,
            PlanoId = request.PlanoId,
            ValorMensal = request.ValorMensal,
            DiaCobranca = request.DiaCobranca,
            Status = request.Status,
            DataInicio = request.DataInicio,
            DataFim = request.DataFim,
            AtualizadoPor = request.UsuarioId
        };

        var atualizada = await _assinaturaRepository.UpdateAsync(assinatura);
        if (atualizada is null)
        {
            return new ResponseBase<Assinatura> { Success = false, Message = "Assinatura não encontrada." };
        }

        return new ResponseBase<Assinatura> { Data = atualizada, Message = "Assinatura atualizada com sucesso." };
    }
}
