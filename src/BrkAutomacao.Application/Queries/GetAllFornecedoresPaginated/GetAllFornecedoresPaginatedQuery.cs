using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllFornecedoresPaginated;

public class GetAllFornecedoresPaginatedQuery : IRequest<ResponseBase<PaginatedList<Fornecedor>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
