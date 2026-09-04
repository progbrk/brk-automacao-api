using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateComissaoCommand;

public class CreateComissaoCommandHandler : IRequestHandler<CreateComissaoCommand, ResponseBase<Comissao>>
{
    private readonly IComissaoRepository _comissaoRepository;

    public CreateComissaoCommandHandler(IComissaoRepository comissaoRepository)
    {
        _comissaoRepository = comissaoRepository;
    }

    public async Task<ResponseBase<Comissao>> Handle(CreateComissaoCommand request, CancellationToken cancellationToken)
    {
        var comissao = new Comissao
        {
            ParceiroId = request.ParceiroId,
            VendaId = request.VendaId,
            Valor = request.Valor,
            Status = request.Status,
            DataPagamento = request.DataPagamento,
            CriadoEm = DateTimeOffset.UtcNow,
            AtualizadoEm = DateTimeOffset.UtcNow,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criada = await _comissaoRepository.AddAsync(comissao);

        return new ResponseBase<Comissao> { Data = criada, Message = "Comissão criada com sucesso." };
    }
}
