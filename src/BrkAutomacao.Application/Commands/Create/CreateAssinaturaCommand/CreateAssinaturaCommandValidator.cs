using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateAssinaturaCommand;

public class CreateAssinaturaCommandValidator : AbstractValidator<CreateAssinaturaCommand>
{
    private static readonly string[] StatusValidos = { "ativa", "suspensa", "cancelada" };

    public CreateAssinaturaCommandValidator()
    {
        RuleFor(a => a.ClienteId).NotEmpty();
        RuleFor(a => a.ValorMensal).GreaterThan(0);
        RuleFor(a => a.DiaCobranca).InclusiveBetween((short)1, (short)28);
        RuleFor(a => a.Status).NotEmpty()
            .Must(s => StatusValidos.Contains(s))
            .WithMessage($"Status deve ser um de: {string.Join(", ", StatusValidos)}.");
    }
}
