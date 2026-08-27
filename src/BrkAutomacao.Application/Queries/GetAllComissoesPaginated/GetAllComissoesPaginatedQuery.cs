using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllComissoesPaginated;

public class GetAllComissoesPaginatedQuery : IRequest<ResponseBase<PaginatedList<Comissao>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
