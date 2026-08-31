using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdatePlanoAssinaturaCommand;

public class UpdatePlanoAssinaturaCommand : IRequest<ResponseBase<PlanoAssinatura>>
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public decimal? ValorMensal { get; set; }
    public bool Ativo { get; set; } = true;
    public Guid UsuarioId { get; set; }
}
