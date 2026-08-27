using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetVendaById;

public class GetVendaByIdQueryHandler : IRequestHandler<GetVendaByIdQuery, ResponseBase<Venda>>
{
    private readonly IVendaRepository _vendaRepository;

    public GetVendaByIdQueryHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<ResponseBase<Venda>> Handle(GetVendaByIdQuery request, CancellationToken cancellationToken)
    {
        var venda = await _vendaRepository.GetByIdAsync(request.Id);
        if (venda is null)
        {
            return new ResponseBase<Venda> { Success = false, Message = "Venda não encontrada." };
        }

        return new ResponseBase<Venda> { Data = venda };
    }
}
