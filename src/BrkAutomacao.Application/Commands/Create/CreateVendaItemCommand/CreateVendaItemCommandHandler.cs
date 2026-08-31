using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateVendaItemCommand;

public class CreateVendaItemCommandHandler : IRequestHandler<CreateVendaItemCommand, ResponseBase<VendaItem>>
{
    private readonly IVendaItemRepository _vendaItemRepository;

    public CreateVendaItemCommandHandler(IVendaItemRepository vendaItemRepository)
    {
        _vendaItemRepository = vendaItemRepository;
    }

    public async Task<ResponseBase<VendaItem>> Handle(CreateVendaItemCommand request, CancellationToken cancellationToken)
    {
        var item = new VendaItem
        {
            VendaId = request.VendaId,
            ProdutoId = request.ProdutoId,
            Quantidade = request.Quantidade,
            PrecoUnitario = request.PrecoUnitario,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _vendaItemRepository.AddAsync(item);

        return new ResponseBase<VendaItem> { Data = criado, Message = "Item adicionado à venda com sucesso." };
    }
}
