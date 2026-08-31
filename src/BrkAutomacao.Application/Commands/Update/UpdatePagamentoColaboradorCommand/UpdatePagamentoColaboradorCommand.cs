using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdatePagamentoColaboradorCommand;

public class UpdatePagamentoColaboradorCommand : IRequest<ResponseBase<PagamentoColaborador>>
{
    public Guid Id { get; set; }
    public Guid ColaboradorId { get; set; }
    public Guid VendaServicoId { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; } = "pendente";
    public DateOnly? DataPagamento { get; set; }
    public Guid UsuarioId { get; set; }
}
