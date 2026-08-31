using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateAssinaturaCommand;

public class CreateAssinaturaCommand : IRequest<ResponseBase<Assinatura>>
{
    public Guid ClienteId { get; set; }
    public Guid? VendaId { get; set; }
    public Guid PlanoId { get; set; }
    public decimal ValorMensal { get; set; }
    public short DiaCobranca { get; set; }
    public string Status { get; set; } = "ativa";
    public DateOnly? DataInicio { get; set; }
    public DateOnly? DataFim { get; set; }

    public Guid UsuarioId { get; set; }
}
