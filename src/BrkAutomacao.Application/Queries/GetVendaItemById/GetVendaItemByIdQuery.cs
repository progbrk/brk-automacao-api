using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetVendaItemById;

public class GetVendaItemByIdQuery : IRequest<ResponseBase<VendaItem>>
{
    public Guid Id { get; set; }

    public GetVendaItemByIdQuery(Guid id)
    {
        Id = id;
    }
}
