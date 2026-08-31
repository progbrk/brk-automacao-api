using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllVendaServicosPaginated;

public class GetAllVendaServicosPaginatedQueryHandler
    : IRequestHandler<GetAllVendaServicosPaginatedQuery, ResponseBase<PaginatedList<VendaServico>>>
{
    private readonly IVendaServicoRepository _vendaServicoRepository;

    public GetAllVendaServicosPaginatedQueryHandler(IVendaServicoRepository vendaServicoRepository)
    {
        _vendaServicoRepository = vendaServicoRepository;
    }

    public async Task<ResponseBase<PaginatedList<VendaServico>>> Handle(
        GetAllVendaServicosPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _vendaServicoRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<VendaServico>> { Data = pagina };
    }
}
