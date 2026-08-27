using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteAssinaturaCommand;

public class DeleteAssinaturaCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
