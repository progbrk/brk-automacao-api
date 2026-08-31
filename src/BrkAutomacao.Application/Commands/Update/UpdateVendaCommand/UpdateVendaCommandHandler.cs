using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateVendaCommand;

public class UpdateVendaCommandHandler : IRequestHandler<UpdateVendaCommand, ResponseBase<Venda>>
{
    private readonly IVendaRepository _vendaRepository;

    public UpdateVendaCommandHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<ResponseBase<Venda>> Handle(UpdateVendaCommand request, CancellationToken cancellationToken)
    {
        var venda = new Venda
        {
            Id = request.Id,
            ClienteId = request.ClienteId,
            ParceiroId = request.ParceiroId,
            Descricao = request.Descricao,
            Status = request.Status,
            DataVenda = request.DataVenda,
            AtualizadoPor = request.UsuarioId
        };

        var atualizada = await _vendaRepository.UpdateAsync(venda);
        if (atualizada is null)
        {
            return new ResponseBase<Venda> { Success = false, Message = "Venda não encontrada." };
        }

        return new ResponseBase<Venda> { Data = atualizada, Message = "Venda atualizada com sucesso." };
    }
}
