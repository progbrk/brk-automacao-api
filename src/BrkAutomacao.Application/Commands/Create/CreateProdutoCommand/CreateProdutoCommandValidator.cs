using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateProdutoCommand;

public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
{
    public CreateProdutoCommandValidator()
    {
        RuleFor(p => p.Nome).NotEmpty().MaximumLength(200);
    }
}
