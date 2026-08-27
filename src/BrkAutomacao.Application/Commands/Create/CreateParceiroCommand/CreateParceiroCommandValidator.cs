using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateParceiroCommand;

public class CreateParceiroCommandValidator : AbstractValidator<CreateParceiroCommand>
{
    public CreateParceiroCommandValidator()
    {
        RuleFor(p => p.Nome).NotEmpty().MaximumLength(200);
        RuleFor(p => p.PercentualComissao).InclusiveBetween(0, 100);
    }
}
