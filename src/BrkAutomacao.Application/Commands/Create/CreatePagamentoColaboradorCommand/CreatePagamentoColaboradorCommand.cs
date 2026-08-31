using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreatePagamentoColaboradorCommand;

public class CreatePagamentoColaboradorCommand : IRequest<ResponseBase<PagamentoColaborador>>
{
    public Guid ColaboradorId { get; set; }
    public Guid VendaServicoId { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; } = "pendente";
    public DateOnly? DataPagamento { get; set; }

    public Guid UsuarioId { get; set; }
}
