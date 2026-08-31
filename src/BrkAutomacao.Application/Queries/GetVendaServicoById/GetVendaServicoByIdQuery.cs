using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetVendaServicoById;

public class GetVendaServicoByIdQuery : IRequest<ResponseBase<VendaServico>>
{
    public Guid Id { get; set; }

    public GetVendaServicoByIdQuery(Guid id)
    {
        Id = id;
    }
}
