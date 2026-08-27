using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllEquipamentosPaginated;

public class GetAllEquipamentosPaginatedQueryHandler
    : IRequestHandler<GetAllEquipamentosPaginatedQuery, ResponseBase<PaginatedList<Equipamento>>>
{
    private readonly IEquipamentoRepository _equipamentoRepository;

    public GetAllEquipamentosPaginatedQueryHandler(IEquipamentoRepository equipamentoRepository)
    {
        _equipamentoRepository = equipamentoRepository;
    }

    public async Task<ResponseBase<PaginatedList<Equipamento>>> Handle(
        GetAllEquipamentosPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _equipamentoRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Equipamento>> { Data = pagina };
    }
}
