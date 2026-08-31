using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllVendaServicosPaginated;

public class GetAllVendaServicosPaginatedQuery : IRequest<ResponseBase<PaginatedList<VendaServico>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
