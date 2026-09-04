using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreatePagamentoColaboradorCommand;

public class CreatePagamentoColaboradorCommandHandler : IRequestHandler<CreatePagamentoColaboradorCommand, ResponseBase<PagamentoColaborador>>
{
    private readonly IPagamentoColaboradorRepository _pagamentoColaboradorRepository;

    public CreatePagamentoColaboradorCommandHandler(IPagamentoColaboradorRepository pagamentoColaboradorRepository)
    {
        _pagamentoColaboradorRepository = pagamentoColaboradorRepository;
    }

    public async Task<ResponseBase<PagamentoColaborador>> Handle(CreatePagamentoColaboradorCommand request, CancellationToken cancellationToken)
    {
        var pagamento = new PagamentoColaborador
        {
            ColaboradorId = request.ColaboradorId,
            VendaServicoId = request.VendaServicoId,
            Valor = request.Valor,
            Status = request.Status,
            DataPagamento = request.DataPagamento,
            CriadoEm = DateTimeOffset.UtcNow,
            AtualizadoEm = DateTimeOffset.UtcNow,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _pagamentoColaboradorRepository.AddAsync(pagamento);

        return new ResponseBase<PagamentoColaborador> { Data = criado, Message = "Pagamento de colaborador criado com sucesso." };
    }
}
