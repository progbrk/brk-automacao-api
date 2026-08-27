using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetParceiroById;

public class GetParceiroByIdQuery : IRequest<ResponseBase<Parceiro>>
{
    public Guid Id { get; set; }

    public GetParceiroByIdQuery(Guid id)
    {
        Id = id;
    }
}
