using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteVendaServicoCommand;

public class DeleteVendaServicoCommandHandler : IRequestHandler<DeleteVendaServicoCommand, ResponseBase<bool>>
{
    private readonly IVendaServicoRepository _vendaServicoRepository;

    public DeleteVendaServicoCommandHandler(IVendaServicoRepository vendaServicoRepository)
    {
        _vendaServicoRepository = vendaServicoRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteVendaServicoCommand request, CancellationToken cancellationToken)
    {
        var removido = await _vendaServicoRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Serviço de venda removido com sucesso." : "Serviço de venda não encontrado."
        };
    }
}
