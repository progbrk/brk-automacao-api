using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteEquipamentoCommand;

public class DeleteEquipamentoCommand : IRequest<ResponseBase<bool>>
{
    public Guid Id { get; set; }
}
