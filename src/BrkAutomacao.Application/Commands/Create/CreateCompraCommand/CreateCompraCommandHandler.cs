using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateCompraCommand;

public class CreateCompraCommandHandler : IRequestHandler<CreateCompraCommand, ResponseBase<Compra>>
{
    private readonly ICompraRepository _compraRepository;

    public CreateCompraCommandHandler(ICompraRepository compraRepository)
    {
        _compraRepository = compraRepository;
    }

    public async Task<ResponseBase<Compra>> Handle(CreateCompraCommand request, CancellationToken cancellationToken)
    {
        var compra = new Compra
        {
            FornecedorId = request.FornecedorId,
            VendaId = request.VendaId,
            Item = request.Item,
            Quantidade = request.Quantidade,
            ValorUnitario = request.ValorUnitario,
            Frete = request.Frete,
            Imposto = request.Imposto,
            DataCompra = request.DataCompra ?? DateOnly.FromDateTime(DateTime.UtcNow),
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criada = await _compraRepository.AddAsync(compra);

        return new ResponseBase<Compra> { Data = criada, Message = "Compra criada com sucesso." };
    }
}
