using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateServicoCommand;

public class CreateServicoCommandValidator : AbstractValidator<CreateServicoCommand>
{
    public CreateServicoCommandValidator()
    {
        RuleFor(s => s.Nome).NotEmpty().MaximumLength(200);
    }
}
