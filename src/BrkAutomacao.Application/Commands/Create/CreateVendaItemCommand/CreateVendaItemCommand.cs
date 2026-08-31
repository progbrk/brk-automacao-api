using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateVendaItemCommand;

public class CreateVendaItemCommand : IRequest<ResponseBase<VendaItem>>
{
    public Guid VendaId { get; set; }
    public Guid ProdutoId { get; set; }
    public decimal Quantidade { get; set; } = 1;
    public decimal PrecoUnitario { get; set; }

    public Guid UsuarioId { get; set; }
}
