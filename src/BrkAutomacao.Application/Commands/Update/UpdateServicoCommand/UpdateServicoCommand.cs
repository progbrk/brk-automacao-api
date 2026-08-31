using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateServicoCommand;

public class UpdateServicoCommand : IRequest<ResponseBase<Servico>>
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public decimal? Preco { get; set; }
    public bool Ativo { get; set; } = true;
    public Guid UsuarioId { get; set; }
}
