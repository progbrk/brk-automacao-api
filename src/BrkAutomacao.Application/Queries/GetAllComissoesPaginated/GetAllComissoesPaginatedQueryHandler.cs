using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllComissoesPaginated;

public class GetAllComissoesPaginatedQueryHandler
    : IRequestHandler<GetAllComissoesPaginatedQuery, ResponseBase<PaginatedList<Comissao>>>
{
    private readonly IComissaoRepository _comissaoRepository;

    public GetAllComissoesPaginatedQueryHandler(IComissaoRepository comissaoRepository)
    {
        _comissaoRepository = comissaoRepository;
    }

    public async Task<ResponseBase<PaginatedList<Comissao>>> Handle(
        GetAllComissoesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _comissaoRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Comissao>> { Data = pagina };
    }
}
