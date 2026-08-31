using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeletePlanoAssinaturaCommand;

public class DeletePlanoAssinaturaCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
