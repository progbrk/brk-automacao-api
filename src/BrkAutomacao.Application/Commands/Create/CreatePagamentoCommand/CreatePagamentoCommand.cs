using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreatePagamentoCommand;

public class CreatePagamentoCommand : IRequest<ResponseBase<Pagamento>>
{
    public Guid ClienteId { get; set; }
    public Guid? VendaId { get; set; }
    public Guid? AssinaturaId { get; set; }
    public decimal Valor { get; set; }
    public string? FormaPagamento { get; set; }
    public string Status { get; set; } = "pendente";
    public DateOnly? DataPagamento { get; set; }

    public Guid UsuarioId { get; set; }
}
