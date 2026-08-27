using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteClienteCommand;

public class DeleteClienteCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
