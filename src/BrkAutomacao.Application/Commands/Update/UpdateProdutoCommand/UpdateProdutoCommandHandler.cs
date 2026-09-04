using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateProdutoCommand;

public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, ResponseBase<Produto>>
{
    private readonly IProdutoRepository _produtoRepository;

    public UpdateProdutoCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ResponseBase<Produto>> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = new Produto
        {
            Id = request.Id,
            Nome = request.Nome,
            Descricao = request.Descricao,
            PrecoVenda = request.PrecoVenda,
            CustoBase = request.CustoBase,
            Ativo = request.Ativo,
            AtualizadoEm = DateTimeOffset.UtcNow,
            AtualizadoPor = request.UsuarioId,
        };

        var atualizado = await _produtoRepository.UpdateAsync(produto);
        if (atualizado is null)
        {
            return new ResponseBase<Produto> { Success = false, Message = "Produto não encontrado." };
        }

        return new ResponseBase<Produto> { Data = atualizado, Message = "Produto atualizado com sucesso." };
    }
}
