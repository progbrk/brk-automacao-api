using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteVendaItemCommand;

public class DeleteVendaItemCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
