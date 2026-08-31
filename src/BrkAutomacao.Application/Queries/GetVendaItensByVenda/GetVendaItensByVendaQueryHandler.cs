using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetVendaItensByVenda;

public class GetVendaItensByVendaQueryHandler : IRequestHandler<GetVendaItensByVendaQuery, ResponseBase<List<VendaItem>>>
{
    private readonly IVendaItemRepository _vendaItemRepository;

    public GetVendaItensByVendaQueryHandler(IVendaItemRepository vendaItemRepository)
    {
        _vendaItemRepository = vendaItemRepository;
    }

    public async Task<ResponseBase<List<VendaItem>>> Handle(GetVendaItensByVendaQuery request, CancellationToken cancellationToken)
    {
        var itens = await _vendaItemRepository.GetByVendaIdAsync(request.VendaId);
        return new ResponseBase<List<VendaItem>> { Data = itens };
    }
}
