using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeletePagamentoColaboradorCommand;

public class DeletePagamentoColaboradorCommandHandler : IRequestHandler<DeletePagamentoColaboradorCommand, ResponseBase<bool>>
{
    private readonly IPagamentoColaboradorRepository _pagamentoColaboradorRepository;

    public DeletePagamentoColaboradorCommandHandler(IPagamentoColaboradorRepository pagamentoColaboradorRepository)
    {
        _pagamentoColaboradorRepository = pagamentoColaboradorRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeletePagamentoColaboradorCommand request, CancellationToken cancellationToken)
    {
        var removido = await _pagamentoColaboradorRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Pagamento de colaborador removido com sucesso." : "Pagamento de colaborador não encontrado."
        };
    }
}
