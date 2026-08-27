using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeletePagamentoCommand;

public class DeletePagamentoCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
