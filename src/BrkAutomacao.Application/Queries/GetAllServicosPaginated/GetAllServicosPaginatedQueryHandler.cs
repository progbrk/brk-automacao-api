using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllServicosPaginated;

public class GetAllServicosPaginatedQueryHandler
    : IRequestHandler<GetAllServicosPaginatedQuery, ResponseBase<PaginatedList<Servico>>>
{
    private readonly IServicoRepository _servicoRepository;

    public GetAllServicosPaginatedQueryHandler(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }

    public async Task<ResponseBase<PaginatedList<Servico>>> Handle(
        GetAllServicosPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _servicoRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Servico>> { Data = pagina };
    }
}
