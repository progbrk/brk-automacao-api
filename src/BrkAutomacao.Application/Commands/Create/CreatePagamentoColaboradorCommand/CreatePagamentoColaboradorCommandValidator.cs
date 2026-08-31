using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreatePagamentoColaboradorCommand;

public class CreatePagamentoColaboradorCommandValidator : AbstractValidator<CreatePagamentoColaboradorCommand>
{
    private static readonly string[] StatusValidos = { "pendente", "pago" };

    public CreatePagamentoColaboradorCommandValidator()
    {
        RuleFor(p => p.ColaboradorId).NotEmpty();
        RuleFor(p => p.VendaServicoId).NotEmpty();
        RuleFor(p => p.Valor).GreaterThan(0);
        RuleFor(p => p.Status).NotEmpty()
            .Must(s => StatusValidos.Contains(s))
            .WithMessage($"Status deve ser um de: {string.Join(", ", StatusValidos)}.");
    }
}
