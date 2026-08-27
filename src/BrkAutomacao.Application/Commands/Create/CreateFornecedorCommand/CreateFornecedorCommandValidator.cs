using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateFornecedorCommand;

public class CreateFornecedorCommandValidator : AbstractValidator<CreateFornecedorCommand>
{
    public CreateFornecedorCommandValidator()
    {
        RuleFor(f => f.Nome).NotEmpty().MaximumLength(200);
        RuleFor(f => f.Email).EmailAddress().When(f => !string.IsNullOrWhiteSpace(f.Email));
    }
}
