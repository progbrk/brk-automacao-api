using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetClienteById;

public class GetClienteByIdQuery : IRequest<ResponseBase<Cliente>>
{
    public Guid Id { get; set; }

    public GetClienteByIdQuery(Guid id)
    {
        Id = id;
    }
}
