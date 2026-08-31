using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteColaboradorCommand;

public class DeleteColaboradorCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
