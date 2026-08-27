using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateProdutoCommand;

public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
{
    private static readonly string[] TiposValidos = { "instalacao", "assinatura", "peca" };

    public CreateProdutoCommandValidator()
    {
        RuleFor(p => p.Nome).NotEmpty().MaximumLength(200);
        RuleFor(p => p.Tipo).NotEmpty()
            .Must(t => TiposValidos.Contains(t))
            .WithMessage($"Tipo deve ser um de: {string.Join(", ", TiposValidos)}.");
    }
}
