using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateParceiroCommand;

public class CreateParceiroCommand : IRequest<ResponseBase<Parceiro>>
{
    public string Nome { get; set; } = null!;
    public string Tipo { get; set; } = "instalacao_hidraulica";
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public decimal PercentualComissao { get; set; }

    public Guid UsuarioId { get; set; }
}
