using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateVendaItemCommand;

public class CreateVendaItemCommandValidator : AbstractValidator<CreateVendaItemCommand>
{
    public CreateVendaItemCommandValidator()
    {
        RuleFor(i => i.VendaId).NotEmpty();
        RuleFor(i => i.ProdutoId).NotEmpty();
        RuleFor(i => i.Quantidade).GreaterThan(0);
        RuleFor(i => i.PrecoUnitario).GreaterThan(0);
    }
}
