using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllAssinaturasPaginated;

public class GetAllAssinaturasPaginatedQueryHandler
    : IRequestHandler<GetAllAssinaturasPaginatedQuery, ResponseBase<PaginatedList<Assinatura>>>
{
    private readonly IAssinaturaRepository _assinaturaRepository;

    public GetAllAssinaturasPaginatedQueryHandler(IAssinaturaRepository assinaturaRepository)
    {
        _assinaturaRepository = assinaturaRepository;
    }

    public async Task<ResponseBase<PaginatedList<Assinatura>>> Handle(
        GetAllAssinaturasPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _assinaturaRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Assinatura>> { Data = pagina };
    }
}
