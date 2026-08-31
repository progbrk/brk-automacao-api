using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeletePlanoAssinaturaCommand;

public class DeletePlanoAssinaturaCommandHandler : IRequestHandler<DeletePlanoAssinaturaCommand, ResponseBase<bool>>
{
    private readonly IPlanoAssinaturaRepository _planoAssinaturaRepository;

    public DeletePlanoAssinaturaCommandHandler(IPlanoAssinaturaRepository planoAssinaturaRepository)
    {
        _planoAssinaturaRepository = planoAssinaturaRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeletePlanoAssinaturaCommand request, CancellationToken cancellationToken)
    {
        var removido = await _planoAssinaturaRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Plano de assinatura removido com sucesso." : "Plano de assinatura não encontrado."
        };
    }
}
