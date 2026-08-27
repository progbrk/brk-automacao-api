using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeletePagamentoCommand;

public class DeletePagamentoCommandHandler : IRequestHandler<DeletePagamentoCommand, ResponseBase<bool>>
{
    private readonly IPagamentoRepository _pagamentoRepository;

    public DeletePagamentoCommandHandler(IPagamentoRepository pagamentoRepository)
    {
        _pagamentoRepository = pagamentoRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeletePagamentoCommand request, CancellationToken cancellationToken)
    {
        var removido = await _pagamentoRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Pagamento removido com sucesso." : "Pagamento não encontrado."
        };
    }
}
