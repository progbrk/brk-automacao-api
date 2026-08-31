using FluentValidation;

namespace BrkAutomacao.Application.Commands.Create.CreateVendaServicoCommand;

public class CreateVendaServicoCommandValidator : AbstractValidator<CreateVendaServicoCommand>
{
    public CreateVendaServicoCommandValidator()
    {
        RuleFor(i => i.VendaId).NotEmpty();
        RuleFor(i => i.ServicoId).NotEmpty();
        RuleFor(i => i.Quantidade).GreaterThan(0);
        RuleFor(i => i.PrecoUnitario).GreaterThan(0);
    }
}
