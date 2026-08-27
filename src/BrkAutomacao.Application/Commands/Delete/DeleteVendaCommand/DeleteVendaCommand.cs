using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteVendaCommand;

public class DeleteVendaCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
