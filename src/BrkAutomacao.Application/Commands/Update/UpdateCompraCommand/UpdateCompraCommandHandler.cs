using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateCompraCommand;

public class UpdateCompraCommandHandler : IRequestHandler<UpdateCompraCommand, ResponseBase<Compra>>
{
    private readonly ICompraRepository _compraRepository;

    public UpdateCompraCommandHandler(ICompraRepository compraRepository)
    {
        _compraRepository = compraRepository;
    }

    public async Task<ResponseBase<Compra>> Handle(UpdateCompraCommand request, CancellationToken cancellationToken)
    {
        var compra = new Compra
        {
            Id = request.Id,
            FornecedorId = request.FornecedorId,
            VendaId = request.VendaId,
            Item = request.Item,
            Quantidade = request.Quantidade,
            ValorUnitario = request.ValorUnitario,
            Frete = request.Frete,
            Imposto = request.Imposto,
            DataCompra = request.DataCompra,
            AtualizadoPor = request.UsuarioId
        };

        var atualizada = await _compraRepository.UpdateAsync(compra);
        if (atualizada is null)
        {
            return new ResponseBase<Compra> { Success = false, Message = "Compra não encontrada." };
        }

        return new ResponseBase<Compra> { Data = atualizada, Message = "Compra atualizada com sucesso." };
    }
}
