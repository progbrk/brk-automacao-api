using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateEquipamentoCommand;

public class UpdateEquipamentoCommand : IRequest<ResponseBase<Equipamento>>
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid? VendaId { get; set; }
    public string TipoDispositivo { get; set; } = "KC868-A16";
    public string? Identificador { get; set; }
    public string? IpVpn { get; set; }
    public string Status { get; set; } = "ativo";
    public DateOnly? DataInstalacao { get; set; }
    public Guid UsuarioId { get; set; }
}
