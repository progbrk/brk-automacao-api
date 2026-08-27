using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetPagamentoById;

public class GetPagamentoByIdQueryHandler : IRequestHandler<GetPagamentoByIdQuery, ResponseBase<Pagamento>>
{
    private readonly IPagamentoRepository _pagamentoRepository;

    public GetPagamentoByIdQueryHandler(IPagamentoRepository pagamentoRepository)
    {
        _pagamentoRepository = pagamentoRepository;
    }

    public async Task<ResponseBase<Pagamento>> Handle(GetPagamentoByIdQuery request, CancellationToken cancellationToken)
    {
        var pagamento = await _pagamentoRepository.GetByIdAsync(request.Id);
        if (pagamento is null)
        {
            return new ResponseBase<Pagamento> { Success = false, Message = "Pagamento não encontrado." };
        }

        return new ResponseBase<Pagamento> { Data = pagamento };
    }
}
