using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateVendaCommand;

public class CreateVendaCommand : IRequest<ResponseBase<Venda>>
{
    public Guid ClienteId { get; set; }
    public Guid? ParceiroId { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; } = "orcamento";
    public DateOnly? DataVenda { get; set; }

    public Guid UsuarioId { get; set; }
}
