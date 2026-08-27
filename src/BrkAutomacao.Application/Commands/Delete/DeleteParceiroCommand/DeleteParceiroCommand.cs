using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteParceiroCommand;

public class DeleteParceiroCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
