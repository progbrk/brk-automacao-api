using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateLoginCommand;

public class CreateLoginCommand : IRequest<ResponseBase<string>>
{
    public string Usuario { get; set; } = null!;
    public string Senha { get; set; } = null!;
}
