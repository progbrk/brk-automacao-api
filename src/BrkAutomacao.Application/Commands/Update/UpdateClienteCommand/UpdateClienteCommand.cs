using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateClienteCommand;

public class UpdateClienteCommand : IRequest<ResponseBase<Cliente>>
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? CpfCnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Endereco { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Cep { get; set; }
    public string? Observacoes { get; set; }
    public Guid UsuarioId { get; set; }
}
