using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetVendaServicoById;

public class GetVendaServicoByIdQueryHandler : IRequestHandler<GetVendaServicoByIdQuery, ResponseBase<VendaServico>>
{
    private readonly IVendaServicoRepository _vendaServicoRepository;

    public GetVendaServicoByIdQueryHandler(IVendaServicoRepository vendaServicoRepository)
    {
        _vendaServicoRepository = vendaServicoRepository;
    }

    public async Task<ResponseBase<VendaServico>> Handle(GetVendaServicoByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _vendaServicoRepository.GetByIdAsync(request.Id);
        if (item is null)
        {
            return new ResponseBase<VendaServico> { Success = false, Message = "Serviço de venda não encontrado." };
        }

        return new ResponseBase<VendaServico> { Data = item };
    }
}
