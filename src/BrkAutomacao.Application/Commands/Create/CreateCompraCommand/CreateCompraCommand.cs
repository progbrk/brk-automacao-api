using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateCompraCommand;

public class CreateCompraCommand : IRequest<ResponseBase<Compra>>
{
    public Guid FornecedorId { get; set; }
    public Guid? VendaId { get; set; }
    public string Item { get; set; } = null!;
    public decimal Quantidade { get; set; } = 1;
    public decimal ValorUnitario { get; set; }
    public decimal Frete { get; set; }
    public decimal Imposto { get; set; }
    public DateOnly? DataCompra { get; set; }

    public Guid UsuarioId { get; set; }
}
