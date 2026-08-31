using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteColaboradorCommand;

public class DeleteColaboradorCommandHandler : IRequestHandler<DeleteColaboradorCommand, ResponseBase<bool>>
{
    private readonly IColaboradorRepository _colaboradorRepository;

    public DeleteColaboradorCommandHandler(IColaboradorRepository colaboradorRepository)
    {
        _colaboradorRepository = colaboradorRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteColaboradorCommand request, CancellationToken cancellationToken)
    {
        var removido = await _colaboradorRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Colaborador removido com sucesso." : "Colaborador não encontrado."
        };
    }
}
