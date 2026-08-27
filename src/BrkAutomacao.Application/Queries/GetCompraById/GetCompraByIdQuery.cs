using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetCompraById;

public class GetCompraByIdQuery : IRequest<ResponseBase<Compra>>
{
    public Guid Id { get; set; }

    public GetCompraByIdQuery(Guid id)
    {
        Id = id;
    }
}
