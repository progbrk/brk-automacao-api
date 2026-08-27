using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteCompraCommand;

public class DeleteCompraCommandHandler : IRequestHandler<DeleteCompraCommand, ResponseBase<bool>>
{
    private readonly ICompraRepository _compraRepository;

    public DeleteCompraCommandHandler(ICompraRepository compraRepository)
    {
        _compraRepository = compraRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteCompraCommand request, CancellationToken cancellationToken)
    {
        var removida = await _compraRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removida,
            Data = removida,
            Message = removida ? "Compra removida com sucesso." : "Compra não encontrada."
        };
    }
}
