using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateEquipamentoCommand;

public class CreateEquipamentoCommandHandler : IRequestHandler<CreateEquipamentoCommand, ResponseBase<Equipamento>>
{
    private readonly IEquipamentoRepository _equipamentoRepository;

    public CreateEquipamentoCommandHandler(IEquipamentoRepository equipamentoRepository)
    {
        _equipamentoRepository = equipamentoRepository;
    }

    public async Task<ResponseBase<Equipamento>> Handle(CreateEquipamentoCommand request, CancellationToken cancellationToken)
    {
        var equipamento = new Equipamento
        {
            ClienteId = request.ClienteId,
            VendaId = request.VendaId,
            TipoDispositivo = request.TipoDispositivo,
            Identificador = request.Identificador,
            IpVpn = request.IpVpn,
            Status = request.Status,
            DataInstalacao = request.DataInstalacao,
            CriadoEm = DateTimeOffset.UtcNow,
            AtualizadoEm = DateTimeOffset.UtcNow,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _equipamentoRepository.AddAsync(equipamento);

        return new ResponseBase<Equipamento> { Data = criado, Message = "Equipamento criado com sucesso." };
    }
}
