using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdatePagamentoColaboradorCommand;

public class UpdatePagamentoColaboradorCommandHandler : IRequestHandler<UpdatePagamentoColaboradorCommand, ResponseBase<PagamentoColaborador>>
{
    private readonly IPagamentoColaboradorRepository _pagamentoColaboradorRepository;

    public UpdatePagamentoColaboradorCommandHandler(IPagamentoColaboradorRepository pagamentoColaboradorRepository)
    {
        _pagamentoColaboradorRepository = pagamentoColaboradorRepository;
    }

    public async Task<ResponseBase<PagamentoColaborador>> Handle(UpdatePagamentoColaboradorCommand request, CancellationToken cancellationToken)
    {
        var pagamento = new PagamentoColaborador
        {
            Id = request.Id,
            ColaboradorId = request.ColaboradorId,
            VendaServicoId = request.VendaServicoId,
            Valor = request.Valor,
            Status = request.Status,
            DataPagamento = request.DataPagamento,
            AtualizadoPor = request.UsuarioId
        };

        var atualizado = await _pagamentoColaboradorRepository.UpdateAsync(pagamento);
        if (atualizado is null)
        {
            return new ResponseBase<PagamentoColaborador> { Success = false, Message = "Pagamento de colaborador não encontrado." };
        }

        return new ResponseBase<PagamentoColaborador> { Data = atualizado, Message = "Pagamento de colaborador atualizado com sucesso." };
    }
}
