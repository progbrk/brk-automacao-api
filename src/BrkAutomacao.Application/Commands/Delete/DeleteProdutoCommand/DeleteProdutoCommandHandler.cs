using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteProdutoCommand;

public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, ResponseBase<bool>>
{
    private readonly IProdutoRepository _produtoRepository;

    public DeleteProdutoCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
    {
        var removido = await _produtoRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Produto removido com sucesso." : "Produto não encontrado."
        };
    }
}
