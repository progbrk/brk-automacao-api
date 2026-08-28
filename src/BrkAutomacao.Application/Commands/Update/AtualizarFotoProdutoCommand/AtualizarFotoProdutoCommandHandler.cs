using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.AtualizarFotoProdutoCommand;

public class AtualizarFotoProdutoCommandHandler : IRequestHandler<AtualizarFotoProdutoCommand, ResponseBase<Produto>>
{
    private readonly IProdutoRepository _produtoRepository;

    public AtualizarFotoProdutoCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ResponseBase<Produto>> Handle(AtualizarFotoProdutoCommand request, CancellationToken cancellationToken)
    {
        var atualizado = await _produtoRepository.AtualizarFotoAsync(request.Id, request.FotoUrl, request.UsuarioId);
        if (atualizado is null)
        {
            return new ResponseBase<Produto> { Success = false, Message = "Produto não encontrado." };
        }

        return new ResponseBase<Produto> { Data = atualizado, Message = "Foto atualizada com sucesso." };
    }
}
