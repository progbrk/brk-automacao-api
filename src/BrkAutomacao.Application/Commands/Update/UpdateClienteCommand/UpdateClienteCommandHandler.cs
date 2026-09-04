using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateClienteCommand;

public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, ResponseBase<Cliente>>
{
    private readonly IClienteRepository _clienteRepository;

    public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ResponseBase<Cliente>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente
        {
            Id = request.Id,
            Nome = request.Nome,
            CpfCnpj = request.CpfCnpj,
            Telefone = request.Telefone,
            Email = request.Email,
            Endereco = request.Endereco,
            Cidade = request.Cidade,
            Estado = request.Estado,
            Cep = request.Cep,
            Observacoes = request.Observacoes,
            AtualizadoEm = DateTimeOffset.UtcNow,
            AtualizadoPor = request.UsuarioId,
        };

        var atualizado = await _clienteRepository.UpdateAsync(cliente);
        if (atualizado is null)
        {
            return new ResponseBase<Cliente> { Success = false, Message = "Cliente não encontrado." };
        }

        return new ResponseBase<Cliente> { Data = atualizado, Message = "Cliente atualizado com sucesso." };
    }
}
