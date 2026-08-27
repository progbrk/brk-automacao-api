using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteClienteCommand;

public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, ResponseBase<bool>>
{
    private readonly IClienteRepository _clienteRepository;

    public DeleteClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var removido = await _clienteRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Cliente removido com sucesso." : "Cliente não encontrado."
        };
    }
}
