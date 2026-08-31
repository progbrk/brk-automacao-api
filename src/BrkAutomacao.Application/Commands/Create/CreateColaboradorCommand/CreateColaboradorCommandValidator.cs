using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateColaboradorCommand;

public class CreateColaboradorCommandValidator : AbstractValidator<CreateColaboradorCommand>
{
    public CreateColaboradorCommandValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().MaximumLength(200);
        RuleFor(c => c.Email).EmailAddress().When(c => !string.IsNullOrWhiteSpace(c.Email));
    }
}
