using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateClienteCommand;

public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
{
    public CreateClienteCommandValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().MaximumLength(200);
        RuleFor(c => c.Email).EmailAddress().When(c => !string.IsNullOrWhiteSpace(c.Email));
        RuleFor(c => c.Estado).MaximumLength(2).When(c => !string.IsNullOrWhiteSpace(c.Estado));
    }
}
