using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllComprasPaginated;

public class GetAllComprasPaginatedQueryHandler
    : IRequestHandler<GetAllComprasPaginatedQuery, ResponseBase<PaginatedList<Compra>>>
{
    private readonly ICompraRepository _compraRepository;

    public GetAllComprasPaginatedQueryHandler(ICompraRepository compraRepository)
    {
        _compraRepository = compraRepository;
    }

    public async Task<ResponseBase<PaginatedList<Compra>>> Handle(
        GetAllComprasPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _compraRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Compra>> { Data = pagina };
    }
}
