using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetProdutoById;

public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, ResponseBase<Produto>>
{
    private readonly IProdutoRepository _produtoRepository;

    public GetProdutoByIdQueryHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ResponseBase<Produto>> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
    {
        var produto = await _produtoRepository.GetByIdAsync(request.Id);
        if (produto is null)
        {
            return new ResponseBase<Produto> { Success = false, Message = "Produto não encontrado." };
        }

        return new ResponseBase<Produto> { Data = produto };
    }
}
