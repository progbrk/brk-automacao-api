using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreatePagamentoCommand;

public class CreatePagamentoCommandValidator : AbstractValidator<CreatePagamentoCommand>
{
    private static readonly string[] StatusValidos = { "pendente", "pago", "atrasado" };

    public CreatePagamentoCommandValidator()
    {
        RuleFor(p => p.ClienteId).NotEmpty();
        RuleFor(p => p.Valor).GreaterThan(0);
        RuleFor(p => p.Status).NotEmpty()
            .Must(s => StatusValidos.Contains(s))
            .WithMessage($"Status deve ser um de: {string.Join(", ", StatusValidos)}.");
        RuleFor(p => p)
            .Must(p => p.VendaId is not null || p.AssinaturaId is not null)
            .WithMessage("Informe venda_id ou assinatura_id (pelo menos um).");
    }
}
