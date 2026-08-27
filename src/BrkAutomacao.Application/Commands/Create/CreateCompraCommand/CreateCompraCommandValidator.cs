using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateCompraCommand;

public class CreateCompraCommandValidator : AbstractValidator<CreateCompraCommand>
{
    public CreateCompraCommandValidator()
    {
        RuleFor(c => c.FornecedorId).NotEmpty();
        RuleFor(c => c.Item).NotEmpty().MaximumLength(200);
        RuleFor(c => c.Quantidade).GreaterThan(0);
        RuleFor(c => c.ValorUnitario).GreaterThan(0);
        RuleFor(c => c.Frete).GreaterThanOrEqualTo(0);
        RuleFor(c => c.Imposto).GreaterThanOrEqualTo(0);
    }
}
