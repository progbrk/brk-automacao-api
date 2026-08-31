using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreatePlanoAssinaturaCommand;

public class CreatePlanoAssinaturaCommandValidator : AbstractValidator<CreatePlanoAssinaturaCommand>
{
    public CreatePlanoAssinaturaCommandValidator()
    {
        RuleFor(p => p.Nome).NotEmpty().MaximumLength(200);
    }
}
