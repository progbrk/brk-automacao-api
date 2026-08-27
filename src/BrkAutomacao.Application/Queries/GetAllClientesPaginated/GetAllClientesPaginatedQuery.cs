using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllClientesPaginated;

public class GetAllClientesPaginatedQuery : IRequest<ResponseBase<PaginatedList<Cliente>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
