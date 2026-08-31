using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetVendaItensByVenda;

public class GetVendaItensByVendaQuery : IRequest<ResponseBase<List<VendaItem>>>
{
    public Guid VendaId { get; set; }

    public GetVendaItensByVendaQuery(Guid vendaId)
    {
        VendaId = vendaId;
    }
}
