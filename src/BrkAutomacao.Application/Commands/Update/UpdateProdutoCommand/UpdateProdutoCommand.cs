using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateProdutoCommand;

public class UpdateProdutoCommand : IRequest<ResponseBase<Produto>>
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public decimal? PrecoVenda { get; set; }
    public decimal? CustoBase { get; set; }
    public bool Ativo { get; set; } = true;
    public Guid UsuarioId { get; set; }
}
