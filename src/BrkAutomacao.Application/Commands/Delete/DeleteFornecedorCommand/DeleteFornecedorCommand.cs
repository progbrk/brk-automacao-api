using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteFornecedorCommand;

public class DeleteFornecedorCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
