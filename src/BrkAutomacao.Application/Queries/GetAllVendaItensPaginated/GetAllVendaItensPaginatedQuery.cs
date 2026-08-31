using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllVendaItensPaginated;

public class GetAllVendaItensPaginatedQuery : IRequest<ResponseBase<PaginatedList<VendaItem>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
