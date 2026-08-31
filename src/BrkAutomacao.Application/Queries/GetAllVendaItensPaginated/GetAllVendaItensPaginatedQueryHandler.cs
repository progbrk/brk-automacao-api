using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllVendaItensPaginated;

public class GetAllVendaItensPaginatedQueryHandler
    : IRequestHandler<GetAllVendaItensPaginatedQuery, ResponseBase<PaginatedList<VendaItem>>>
{
    private readonly IVendaItemRepository _vendaItemRepository;

    public GetAllVendaItensPaginatedQueryHandler(IVendaItemRepository vendaItemRepository)
    {
        _vendaItemRepository = vendaItemRepository;
    }

    public async Task<ResponseBase<PaginatedList<VendaItem>>> Handle(
        GetAllVendaItensPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _vendaItemRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<VendaItem>> { Data = pagina };
    }
}
