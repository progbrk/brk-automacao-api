using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetPagamentoColaboradorById;

public class GetPagamentoColaboradorByIdQueryHandler : IRequestHandler<GetPagamentoColaboradorByIdQuery, ResponseBase<PagamentoColaborador>>
{
    private readonly IPagamentoColaboradorRepository _pagamentoColaboradorRepository;

    public GetPagamentoColaboradorByIdQueryHandler(IPagamentoColaboradorRepository pagamentoColaboradorRepository)
    {
        _pagamentoColaboradorRepository = pagamentoColaboradorRepository;
    }

    public async Task<ResponseBase<PagamentoColaborador>> Handle(GetPagamentoColaboradorByIdQuery request, CancellationToken cancellationToken)
    {
        var pagamento = await _pagamentoColaboradorRepository.GetByIdAsync(request.Id);
        if (pagamento is null)
        {
            return new ResponseBase<PagamentoColaborador> { Success = false, Message = "Pagamento de colaborador não encontrado." };
        }

        return new ResponseBase<PagamentoColaborador> { Data = pagamento };
    }
}
