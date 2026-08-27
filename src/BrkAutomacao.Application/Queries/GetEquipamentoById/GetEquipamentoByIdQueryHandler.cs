using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetEquipamentoById;

public class GetEquipamentoByIdQueryHandler : IRequestHandler<GetEquipamentoByIdQuery, ResponseBase<Equipamento>>
{
    private readonly IEquipamentoRepository _equipamentoRepository;

    public GetEquipamentoByIdQueryHandler(IEquipamentoRepository equipamentoRepository)
    {
        _equipamentoRepository = equipamentoRepository;
    }

    public async Task<ResponseBase<Equipamento>> Handle(GetEquipamentoByIdQuery request, CancellationToken cancellationToken)
    {
        var equipamento = await _equipamentoRepository.GetByIdAsync(request.Id);
        if (equipamento is null)
        {
            return new ResponseBase<Equipamento> { Success = false, Message = "Equipamento não encontrado." };
        }

        return new ResponseBase<Equipamento> { Data = equipamento };
    }
}
