using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteParceiroCommand;

public class DeleteParceiroCommandHandler : IRequestHandler<DeleteParceiroCommand, ResponseBase<bool>>
{
    private readonly IParceiroRepository _parceiroRepository;

    public DeleteParceiroCommandHandler(IParceiroRepository parceiroRepository)
    {
        _parceiroRepository = parceiroRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteParceiroCommand request, CancellationToken cancellationToken)
    {
        var removido = await _parceiroRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Parceiro removido com sucesso." : "Parceiro não encontrado."
        };
    }
}
