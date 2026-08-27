using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllAssinaturasPaginated;

public class GetAllAssinaturasPaginatedQuery : IRequest<ResponseBase<PaginatedList<Assinatura>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
