using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateEquipamentoCommand;

public class UpdateEquipamentoCommandHandler : IRequestHandler<UpdateEquipamentoCommand, ResponseBase<Equipamento>>
{
    private readonly IEquipamentoRepository _equipamentoRepository;

    public UpdateEquipamentoCommandHandler(IEquipamentoRepository equipamentoRepository)
    {
        _equipamentoRepository = equipamentoRepository;
    }

    public async Task<ResponseBase<Equipamento>> Handle(UpdateEquipamentoCommand request, CancellationToken cancellationToken)
    {
        var equipamento = new Equipamento
        {
            Id = request.Id,
            ClienteId = request.ClienteId,
            VendaId = request.VendaId,
            TipoDispositivo = request.TipoDispositivo,
            Identificador = request.Identificador,
            IpVpn = request.IpVpn,
            Status = request.Status,
            DataInstalacao = request.DataInstalacao,
            AtualizadoEm = DateTimeOffset.UtcNow,
            AtualizadoPor = request.UsuarioId,
        };

        var atualizado = await _equipamentoRepository.UpdateAsync(equipamento);
        if (atualizado is null)
        {
            return new ResponseBase<Equipamento> { Success = false, Message = "Equipamento não encontrado." };
        }

        return new ResponseBase<Equipamento> { Data = atualizado, Message = "Equipamento atualizado com sucesso." };
    }
}
