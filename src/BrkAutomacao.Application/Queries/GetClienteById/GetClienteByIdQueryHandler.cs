using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetClienteById;

public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, ResponseBase<Cliente>>
{
    private readonly IClienteRepository _clienteRepository;

    public GetClienteByIdQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ResponseBase<Cliente>> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.GetByIdAsync(request.Id);
        if (cliente is null)
        {
            return new ResponseBase<Cliente> { Success = false, Message = "Cliente não encontrado." };
        }

        return new ResponseBase<Cliente> { Data = cliente };
    }
}
