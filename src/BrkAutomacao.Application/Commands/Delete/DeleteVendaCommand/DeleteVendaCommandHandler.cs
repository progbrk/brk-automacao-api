using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteVendaCommand;

public class DeleteVendaCommandHandler : IRequestHandler<DeleteVendaCommand, ResponseBase<bool>>
{
    private readonly IVendaRepository _vendaRepository;

    public DeleteVendaCommandHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteVendaCommand request, CancellationToken cancellationToken)
    {
        var removida = await _vendaRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removida,
            Data = removida,
            Message = removida ? "Venda removida com sucesso." : "Venda não encontrada."
        };
    }
}
