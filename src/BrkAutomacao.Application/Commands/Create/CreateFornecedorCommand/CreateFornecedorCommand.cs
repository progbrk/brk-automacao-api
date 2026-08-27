using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateFornecedorCommand;

public class CreateFornecedorCommand : IRequest<ResponseBase<Fornecedor>>
{
    public string Nome { get; set; } = null!;
    public string? Contato { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }

    public Guid UsuarioId { get; set; }
}
