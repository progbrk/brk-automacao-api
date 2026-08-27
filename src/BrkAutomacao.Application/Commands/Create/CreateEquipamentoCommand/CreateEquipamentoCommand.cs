using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateEquipamentoCommand;

public class CreateEquipamentoCommand : IRequest<ResponseBase<Equipamento>>
{
    public Guid ClienteId { get; set; }
    public Guid? VendaId { get; set; }
    public string TipoDispositivo { get; set; } = "KC868-A16";
    public string? Identificador { get; set; }
    public string? IpVpn { get; set; }
    public string Status { get; set; } = "ativo";
    public DateOnly? DataInstalacao { get; set; }

    public Guid UsuarioId { get; set; }
}
