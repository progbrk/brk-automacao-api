using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteEquipamentoCommand;

public class DeleteEquipamentoCommandHandler : IRequestHandler<DeleteEquipamentoCommand, ResponseBase<bool>>
{
    private readonly IEquipamentoRepository _equipamentoRepository;

    public DeleteEquipamentoCommandHandler(IEquipamentoRepository equipamentoRepository)
    {
        _equipamentoRepository = equipamentoRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteEquipamentoCommand request, CancellationToken cancellationToken)
    {
        var removido = await _equipamentoRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Equipamento removido com sucesso." : "Equipamento não encontrado."
        };
    }
}
