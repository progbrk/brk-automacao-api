using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreatePagamentoCommand;

public class CreatePagamentoCommandHandler : IRequestHandler<CreatePagamentoCommand, ResponseBase<Pagamento>>
{
    private readonly IPagamentoRepository _pagamentoRepository;

    public CreatePagamentoCommandHandler(IPagamentoRepository pagamentoRepository)
    {
        _pagamentoRepository = pagamentoRepository;
    }

    public async Task<ResponseBase<Pagamento>> Handle(CreatePagamentoCommand request, CancellationToken cancellationToken)
    {
        var pagamento = new Pagamento
        {
            ClienteId = request.ClienteId,
            VendaId = request.VendaId,
            AssinaturaId = request.AssinaturaId,
            Valor = request.Valor,
            FormaPagamento = request.FormaPagamento,
            Status = request.Status,
            DataPagamento = request.DataPagamento,
            CriadoEm = DateTimeOffset.UtcNow,
            AtualizadoEm = DateTimeOffset.UtcNow,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _pagamentoRepository.AddAsync(pagamento);

        return new ResponseBase<Pagamento> { Data = criado, Message = "Pagamento criado com sucesso." };
    }
}
