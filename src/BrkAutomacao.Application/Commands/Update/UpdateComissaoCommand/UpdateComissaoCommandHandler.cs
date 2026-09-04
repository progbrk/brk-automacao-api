using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateComissaoCommand;

public class UpdateComissaoCommandHandler : IRequestHandler<UpdateComissaoCommand, ResponseBase<Comissao>>
{
    private readonly IComissaoRepository _comissaoRepository;

    public UpdateComissaoCommandHandler(IComissaoRepository comissaoRepository)
    {
        _comissaoRepository = comissaoRepository;
    }

    public async Task<ResponseBase<Comissao>> Handle(UpdateComissaoCommand request, CancellationToken cancellationToken)
    {
        var comissao = new Comissao
        {
            Id = request.Id,
            ParceiroId = request.ParceiroId,
            VendaId = request.VendaId,
            Valor = request.Valor,
            Status = request.Status,
            DataPagamento = request.DataPagamento,
            AtualizadoEm = DateTimeOffset.UtcNow,
            AtualizadoPor = request.UsuarioId,
        };

        var atualizada = await _comissaoRepository.UpdateAsync(comissao);
        if (atualizada is null)
        {
            return new ResponseBase<Comissao> { Success = false, Message = "Comissão não encontrada." };
        }

        return new ResponseBase<Comissao> { Data = atualizada, Message = "Comissão atualizada com sucesso." };
    }
}
