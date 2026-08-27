using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllPagamentosPaginated;

public class GetAllPagamentosPaginatedQueryHandler
    : IRequestHandler<GetAllPagamentosPaginatedQuery, ResponseBase<PaginatedList<Pagamento>>>
{
    private readonly IPagamentoRepository _pagamentoRepository;

    public GetAllPagamentosPaginatedQueryHandler(IPagamentoRepository pagamentoRepository)
    {
        _pagamentoRepository = pagamentoRepository;
    }

    public async Task<ResponseBase<PaginatedList<Pagamento>>> Handle(
        GetAllPagamentosPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _pagamentoRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Pagamento>> { Data = pagina };
    }
}
