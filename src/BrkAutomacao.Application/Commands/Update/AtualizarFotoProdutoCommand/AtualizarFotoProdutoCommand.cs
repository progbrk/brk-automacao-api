using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.AtualizarFotoProdutoCommand;

public class AtualizarFotoProdutoCommand : IRequest<ResponseBase<Produto>>
{
    public Guid Id { get; set; }
    public string? FotoUrl { get; set; }
    public Guid UsuarioId { get; set; }
}
