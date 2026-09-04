using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateColaboradorCommand;

public class UpdateColaboradorCommand : IRequest<ResponseBase<Colaborador>>
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Cargo { get; set; }
    public string Tipo { get; set; } = "Interno";
    public string? CpfCnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public bool Ativo { get; set; } = true;
    public Guid UsuarioId { get; set; }
}
