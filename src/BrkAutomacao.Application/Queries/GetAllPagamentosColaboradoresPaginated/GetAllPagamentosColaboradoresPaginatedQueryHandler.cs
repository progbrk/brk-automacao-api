using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllPagamentosColaboradoresPaginated;

public class GetAllPagamentosColaboradoresPaginatedQueryHandler
    : IRequestHandler<GetAllPagamentosColaboradoresPaginatedQuery, ResponseBase<PaginatedList<PagamentoColaborador>>>
{
    private readonly IPagamentoColaboradorRepository _pagamentoColaboradorRepository;

    public GetAllPagamentosColaboradoresPaginatedQueryHandler(IPagamentoColaboradorRepository pagamentoColaboradorRepository)
    {
        _pagamentoColaboradorRepository = pagamentoColaboradorRepository;
    }

    public async Task<ResponseBase<PaginatedList<PagamentoColaborador>>> Handle(
        GetAllPagamentosColaboradoresPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _pagamentoColaboradorRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<PagamentoColaborador>> { Data = pagina };
    }
}
