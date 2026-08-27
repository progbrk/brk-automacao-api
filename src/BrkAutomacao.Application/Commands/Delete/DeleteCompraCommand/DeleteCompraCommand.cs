using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteCompraCommand;

public class DeleteCompraCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
