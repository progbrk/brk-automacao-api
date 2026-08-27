using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateFornecedorCommand;

public class UpdateFornecedorCommand : IRequest<ResponseBase<Fornecedor>>
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Contato { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public Guid UsuarioId { get; set; }
}
