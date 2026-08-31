using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateVendaItemCommand;

public class UpdateVendaItemCommandHandler : IRequestHandler<UpdateVendaItemCommand, ResponseBase<VendaItem>>
{
    private readonly IVendaItemRepository _vendaItemRepository;

    public UpdateVendaItemCommandHandler(IVendaItemRepository vendaItemRepository)
    {
        _vendaItemRepository = vendaItemRepository;
    }

    public async Task<ResponseBase<VendaItem>> Handle(UpdateVendaItemCommand request, CancellationToken cancellationToken)
    {
        var item = new VendaItem
        {
            Id = request.Id,
            VendaId = request.VendaId,
            ProdutoId = request.ProdutoId,
            Quantidade = request.Quantidade,
            PrecoUnitario = request.PrecoUnitario,
            AtualizadoPor = request.UsuarioId
        };

        var atualizado = await _vendaItemRepository.UpdateAsync(item);
        if (atualizado is null)
        {
            return new ResponseBase<VendaItem> { Success = false, Message = "Item de venda não encontrado." };
        }

        return new ResponseBase<VendaItem> { Data = atualizado, Message = "Item de venda atualizado com sucesso." };
    }
}
