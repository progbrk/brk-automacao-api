using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllPlanosAssinaturaPaginated;

public class GetAllPlanosAssinaturaPaginatedQuery : IRequest<ResponseBase<PaginatedList<PlanoAssinatura>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
