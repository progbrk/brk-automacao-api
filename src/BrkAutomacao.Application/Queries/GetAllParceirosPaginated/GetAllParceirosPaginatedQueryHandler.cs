using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllParceirosPaginated;

public class GetAllParceirosPaginatedQueryHandler
    : IRequestHandler<GetAllParceirosPaginatedQuery, ResponseBase<PaginatedList<Parceiro>>>
{
    private readonly IParceiroRepository _parceiroRepository;

    public GetAllParceirosPaginatedQueryHandler(IParceiroRepository parceiroRepository)
    {
        _parceiroRepository = parceiroRepository;
    }

    public async Task<ResponseBase<PaginatedList<Parceiro>>> Handle(
        GetAllParceirosPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _parceiroRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Parceiro>> { Data = pagina };
    }
}
