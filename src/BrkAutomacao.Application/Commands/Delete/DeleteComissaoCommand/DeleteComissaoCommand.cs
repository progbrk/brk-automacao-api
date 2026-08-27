using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteComissaoCommand;

public class DeleteComissaoCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
