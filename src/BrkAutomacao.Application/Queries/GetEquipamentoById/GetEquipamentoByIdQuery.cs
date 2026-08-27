using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetEquipamentoById;

public class GetEquipamentoByIdQuery : IRequest<ResponseBase<Equipamento>>
{
    public Guid Id { get; set; }

    public GetEquipamentoByIdQuery(Guid id)
    {
        Id = id;
    }
}
