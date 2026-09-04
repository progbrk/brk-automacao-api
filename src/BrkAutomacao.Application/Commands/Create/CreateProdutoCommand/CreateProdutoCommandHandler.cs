using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateProdutoCommand;

public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, ResponseBase<Produto>>
{
    private readonly IProdutoRepository _produtoRepository;

    public CreateProdutoCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ResponseBase<Produto>> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = new Produto
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            PrecoVenda = request.PrecoVenda,
            CustoBase = request.CustoBase,
            Ativo = request.Ativo,
            CriadoEm = DateTimeOffset.UtcNow,
            AtualizadoEm = DateTimeOffset.UtcNow,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _produtoRepository.AddAsync(produto);

        return new ResponseBase<Produto> { Data = criado, Message = "Produto criado com sucesso." };
    }
}
