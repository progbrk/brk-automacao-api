using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllVendasPaginated;

public class GetAllVendasPaginatedQueryHandler
    : IRequestHandler<GetAllVendasPaginatedQuery, ResponseBase<PaginatedList<Venda>>>
{
    private readonly IVendaRepository _vendaRepository;

    public GetAllVendasPaginatedQueryHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<ResponseBase<PaginatedList<Venda>>> Handle(
        GetAllVendasPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _vendaRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Venda>> { Data = pagina };
    }
}
