using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdatePagamentoCommand;

public class UpdatePagamentoCommandHandler : IRequestHandler<UpdatePagamentoCommand, ResponseBase<Pagamento>>
{
    private readonly IPagamentoRepository _pagamentoRepository;

    public UpdatePagamentoCommandHandler(IPagamentoRepository pagamentoRepository)
    {
        _pagamentoRepository = pagamentoRepository;
    }

    public async Task<ResponseBase<Pagamento>> Handle(UpdatePagamentoCommand request, CancellationToken cancellationToken)
    {
        var pagamento = new Pagamento
        {
            Id = request.Id,
            ClienteId = request.ClienteId,
            VendaId = request.VendaId,
            AssinaturaId = request.AssinaturaId,
            Valor = request.Valor,
            FormaPagamento = request.FormaPagamento,
            Status = request.Status,
            DataPagamento = request.DataPagamento,
            AtualizadoPor = request.UsuarioId
        };

        var atualizado = await _pagamentoRepository.UpdateAsync(pagamento);
        if (atualizado is null)
        {
            return new ResponseBase<Pagamento> { Success = false, Message = "Pagamento não encontrado." };
        }

        return new ResponseBase<Pagamento> { Data = atualizado, Message = "Pagamento atualizado com sucesso." };
    }
}
