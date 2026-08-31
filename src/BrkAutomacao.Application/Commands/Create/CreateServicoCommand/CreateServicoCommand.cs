using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateServicoCommand;

public class CreateServicoCommand : IRequest<ResponseBase<Servico>>
{
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public decimal? Preco { get; set; }
    public bool Ativo { get; set; } = true;

    public Guid UsuarioId { get; set; }
}
