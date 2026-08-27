using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllClientesPaginated;

public class GetAllClientesPaginatedQueryHandler
    : IRequestHandler<GetAllClientesPaginatedQuery, ResponseBase<PaginatedList<Cliente>>>
{
    private readonly IClienteRepository _clienteRepository;

    public GetAllClientesPaginatedQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ResponseBase<PaginatedList<Cliente>>> Handle(
        GetAllClientesPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _clienteRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Cliente>> { Data = pagina };
    }
}
