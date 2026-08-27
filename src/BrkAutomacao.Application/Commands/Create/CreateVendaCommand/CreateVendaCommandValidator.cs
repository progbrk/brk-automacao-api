using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateVendaCommand;

public class CreateVendaCommandValidator : AbstractValidator<CreateVendaCommand>
{
    private static readonly string[] StatusValidos = { "orcamento", "confirmada", "instalada", "cancelada" };

    public CreateVendaCommandValidator()
    {
        RuleFor(v => v.ClienteId).NotEmpty();
        RuleFor(v => v.ProdutoId).NotEmpty();
        RuleFor(v => v.Valor).GreaterThan(0);
        RuleFor(v => v.Status).NotEmpty()
            .Must(s => StatusValidos.Contains(s))
            .WithMessage($"Status deve ser um de: {string.Join(", ", StatusValidos)}.");
    }
}
