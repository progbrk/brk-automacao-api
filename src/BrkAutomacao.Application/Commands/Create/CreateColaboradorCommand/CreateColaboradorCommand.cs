using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateColaboradorCommand;

public class CreateColaboradorCommand : IRequest<ResponseBase<Colaborador>>
{
    public string Nome { get; set; } = null!;
    public string? Cargo { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public bool Ativo { get; set; } = true;

    public Guid UsuarioId { get; set; }
}
