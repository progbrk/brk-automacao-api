using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetVendaServicosByVenda;

public class GetVendaServicosByVendaQuery : IRequest<ResponseBase<List<VendaServico>>>
{
    public Guid VendaId { get; set; }

    public GetVendaServicosByVendaQuery(Guid vendaId)
    {
        VendaId = vendaId;
    }
}
