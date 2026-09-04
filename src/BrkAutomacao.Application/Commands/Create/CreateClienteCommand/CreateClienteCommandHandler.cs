using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateClienteCommand;

public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, ResponseBase<Cliente>>
{
    private readonly IClienteRepository _clienteRepository;

    public CreateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ResponseBase<Cliente>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente
        {
            Nome = request.Nome,
            CpfCnpj = request.CpfCnpj,
            Telefone = request.Telefone,
            Email = request.Email,
            Endereco = request.Endereco,
            Cidade = request.Cidade,
            Estado = request.Estado,
            Cep = request.Cep,
            Observacoes = request.Observacoes,
            CriadoEm = DateTimeOffset.UtcNow,
            AtualizadoEm = DateTimeOffset.UtcNow,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _clienteRepository.AddAsync(cliente);

        return new ResponseBase<Cliente>
        {
            Data = criado,
            Message = "Cliente criado com sucesso."
        };
    }
}
