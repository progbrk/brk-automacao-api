using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateComissaoCommand;

public class CreateComissaoCommand : IRequest<ResponseBase<Comissao>>
{
    public Guid ParceiroId { get; set; }
    public Guid VendaId { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; } = "pendente";
    public DateOnly? DataPagamento { get; set; }

    public Guid UsuarioId { get; set; }
}
