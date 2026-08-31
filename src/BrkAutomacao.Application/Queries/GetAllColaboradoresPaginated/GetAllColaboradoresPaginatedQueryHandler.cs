using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllColaboradoresPaginated;

public class GetAllColaboradoresPaginatedQueryHandler
    : IRequestHandler<GetAllColaboradoresPaginatedQuery, ResponseBase<PaginatedList<Colaborador>>>
{
    private readonly IColaboradorRepository _colaboradorRepository;

    public GetAllColaboradoresPaginatedQueryHandler(IColaboradorRepository colaboradorRepository)
    {
        _colaboradorRepository = colaboradorRepository;
    }

    public async Task<ResponseBase<PaginatedList<Colaborador>>> Handle(
        GetAllColaboradoresPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _colaboradorRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Colaborador>> { Data = pagina };
    }
}
