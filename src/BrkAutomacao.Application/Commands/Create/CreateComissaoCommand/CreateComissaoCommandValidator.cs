using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateComissaoCommand;

public class CreateComissaoCommandValidator : AbstractValidator<CreateComissaoCommand>
{
    private static readonly string[] StatusValidos = { "pendente", "pago" };

    public CreateComissaoCommandValidator()
    {
        RuleFor(c => c.ParceiroId).NotEmpty();
        RuleFor(c => c.VendaId).NotEmpty();
        RuleFor(c => c.Valor).GreaterThan(0);
        RuleFor(c => c.Status).NotEmpty()
            .Must(s => StatusValidos.Contains(s))
            .WithMessage($"Status deve ser um de: {string.Join(", ", StatusValidos)}.");
    }
}
