using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateComissaoCommand;

public class UpdateComissaoCommand : IRequest<ResponseBase<Comissao>>
{
    public Guid Id { get; set; }
    public Guid ParceiroId { get; set; }
    public Guid VendaId { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; } = "pendente";
    public DateOnly? DataPagamento { get; set; }
    public Guid UsuarioId { get; set; }
}
