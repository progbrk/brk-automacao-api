using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateProdutoCommand;

public class CreateProdutoCommand : IRequest<ResponseBase<Produto>>
{
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public decimal? PrecoVenda { get; set; }
    public decimal? CustoBase { get; set; }
    public bool Ativo { get; set; } = true;

    public Guid UsuarioId { get; set; }
}
