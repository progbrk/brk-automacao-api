using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeletePagamentoColaboradorCommand;

public class DeletePagamentoColaboradorCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
