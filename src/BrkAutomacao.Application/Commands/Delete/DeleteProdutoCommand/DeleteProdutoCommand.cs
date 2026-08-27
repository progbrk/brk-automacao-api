using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteProdutoCommand;

public class DeleteProdutoCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
