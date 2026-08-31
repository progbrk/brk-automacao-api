using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteVendaServicoCommand;

public class DeleteVendaServicoCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
