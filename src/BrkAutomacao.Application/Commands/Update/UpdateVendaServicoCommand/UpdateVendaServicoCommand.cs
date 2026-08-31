using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateVendaServicoCommand;

public class UpdateVendaServicoCommand : IRequest<ResponseBase<VendaServico>>
{
    public Guid Id { get; set; }
    public Guid VendaId { get; set; }
    public Guid ServicoId { get; set; }
    public decimal Quantidade { get; set; } = 1;
    public decimal PrecoUnitario { get; set; }
    public Guid UsuarioId { get; set; }
}
