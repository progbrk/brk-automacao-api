using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteAssinaturaCommand;

public class DeleteAssinaturaCommandHandler : IRequestHandler<DeleteAssinaturaCommand, ResponseBase<bool>>
{
    private readonly IAssinaturaRepository _assinaturaRepository;

    public DeleteAssinaturaCommandHandler(IAssinaturaRepository assinaturaRepository)
    {
        _assinaturaRepository = assinaturaRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteAssinaturaCommand request, CancellationToken cancellationToken)
    {
        var removida = await _assinaturaRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removida,
            Data = removida,
            Message = removida ? "Assinatura removida com sucesso." : "Assinatura não encontrada."
        };
    }
}
