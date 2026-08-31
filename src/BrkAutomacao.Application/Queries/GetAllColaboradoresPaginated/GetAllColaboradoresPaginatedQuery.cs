using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllColaboradoresPaginated;

public class GetAllColaboradoresPaginatedQuery : IRequest<ResponseBase<PaginatedList<Colaborador>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
