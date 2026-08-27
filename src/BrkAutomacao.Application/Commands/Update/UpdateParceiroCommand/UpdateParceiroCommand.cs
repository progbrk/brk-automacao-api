using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateParceiroCommand;

public class UpdateParceiroCommand : IRequest<ResponseBase<Parceiro>>
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Tipo { get; set; } = "instalacao_hidraulica";
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public decimal PercentualComissao { get; set; }
    public Guid UsuarioId { get; set; }
}
