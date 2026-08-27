using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateClienteCommand;

public class CreateClienteCommand : IRequest<ResponseBase<Cliente>>
{
    public string Nome { get; set; } = null!;
    public string? CpfCnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Endereco { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Cep { get; set; }
    public string? Observacoes { get; set; }

    /// <summary>Preenchido pelo controller a partir do usuário autenticado (claim), não vem do corpo da requisição.</summary>
    public Guid UsuarioId { get; set; }
}
