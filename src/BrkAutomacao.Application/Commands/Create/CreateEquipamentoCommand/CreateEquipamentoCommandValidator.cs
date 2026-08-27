using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateEquipamentoCommand;

public class CreateEquipamentoCommandValidator : AbstractValidator<CreateEquipamentoCommand>
{
    private static readonly string[] StatusValidos = { "ativo", "inativo", "manutencao" };

    public CreateEquipamentoCommandValidator()
    {
        RuleFor(e => e.ClienteId).NotEmpty();
        RuleFor(e => e.TipoDispositivo).NotEmpty();
        RuleFor(e => e.Status).NotEmpty()
            .Must(s => StatusValidos.Contains(s))
            .WithMessage($"Status deve ser um de: {string.Join(", ", StatusValidos)}.");
        RuleFor(e => e.IpVpn).Must(ip => System.Net.IPAddress.TryParse(ip, out _))
            .When(e => !string.IsNullOrWhiteSpace(e.IpVpn))
            .WithMessage("IP VPN inválido.");
    }
}
