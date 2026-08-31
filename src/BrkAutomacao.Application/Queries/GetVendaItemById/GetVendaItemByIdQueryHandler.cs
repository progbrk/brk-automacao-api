using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetVendaItemById;

public class GetVendaItemByIdQueryHandler : IRequestHandler<GetVendaItemByIdQuery, ResponseBase<VendaItem>>
{
    private readonly IVendaItemRepository _vendaItemRepository;

    public GetVendaItemByIdQueryHandler(IVendaItemRepository vendaItemRepository)
    {
        _vendaItemRepository = vendaItemRepository;
    }

    public async Task<ResponseBase<VendaItem>> Handle(GetVendaItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _vendaItemRepository.GetByIdAsync(request.Id);
        if (item is null)
        {
            return new ResponseBase<VendaItem> { Success = false, Message = "Item de venda não encontrado." };
        }

        return new ResponseBase<VendaItem> { Data = item };
    }
}
