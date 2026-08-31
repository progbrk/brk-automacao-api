using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetVendaServicosByVenda;

public class GetVendaServicosByVendaQueryHandler : IRequestHandler<GetVendaServicosByVendaQuery, ResponseBase<List<VendaServico>>>
{
    private readonly IVendaServicoRepository _vendaServicoRepository;

    public GetVendaServicosByVendaQueryHandler(IVendaServicoRepository vendaServicoRepository)
    {
        _vendaServicoRepository = vendaServicoRepository;
    }

    public async Task<ResponseBase<List<VendaServico>>> Handle(GetVendaServicosByVendaQuery request, CancellationToken cancellationToken)
    {
        var itens = await _vendaServicoRepository.GetByVendaIdAsync(request.VendaId);
        return new ResponseBase<List<VendaServico>> { Data = itens };
    }
}
