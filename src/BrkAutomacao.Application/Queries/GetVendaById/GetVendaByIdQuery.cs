using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetVendaById;

public class GetVendaByIdQuery : IRequest<ResponseBase<Venda>>
{
    public Guid Id { get; set; }

    public GetVendaByIdQuery(Guid id)
    {
        Id = id;
    }
}
