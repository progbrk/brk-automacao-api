using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllProdutosPaginated;

public class GetAllProdutosPaginatedQueryHandler
    : IRequestHandler<GetAllProdutosPaginatedQuery, ResponseBase<PaginatedList<Produto>>>
{
    private readonly IProdutoRepository _produtoRepository;

    public GetAllProdutosPaginatedQueryHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ResponseBase<PaginatedList<Produto>>> Handle(
        GetAllProdutosPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _produtoRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Produto>> { Data = pagina };
    }
}
