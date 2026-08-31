using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllPlanosAssinaturaPaginated;

public class GetAllPlanosAssinaturaPaginatedQueryHandler
    : IRequestHandler<GetAllPlanosAssinaturaPaginatedQuery, ResponseBase<PaginatedList<PlanoAssinatura>>>
{
    private readonly IPlanoAssinaturaRepository _planoAssinaturaRepository;

    public GetAllPlanosAssinaturaPaginatedQueryHandler(IPlanoAssinaturaRepository planoAssinaturaRepository)
    {
        _planoAssinaturaRepository = planoAssinaturaRepository;
    }

    public async Task<ResponseBase<PaginatedList<PlanoAssinatura>>> Handle(
        GetAllPlanosAssinaturaPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _planoAssinaturaRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<PlanoAssinatura>> { Data = pagina };
    }
}
