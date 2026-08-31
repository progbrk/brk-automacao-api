using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteVendaItemCommand;

public class DeleteVendaItemCommandHandler : IRequestHandler<DeleteVendaItemCommand, ResponseBase<bool>>
{
    private readonly IVendaItemRepository _vendaItemRepository;

    public DeleteVendaItemCommandHandler(IVendaItemRepository vendaItemRepository)
    {
        _vendaItemRepository = vendaItemRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteVendaItemCommand request, CancellationToken cancellationToken)
    {
        var removido = await _vendaItemRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Item de venda removido com sucesso." : "Item de venda não encontrado."
        };
    }
}
