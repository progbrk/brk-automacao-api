using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteFornecedorCommand;

public class DeleteFornecedorCommandHandler : IRequestHandler<DeleteFornecedorCommand, ResponseBase<bool>>
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public DeleteFornecedorCommandHandler(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteFornecedorCommand request, CancellationToken cancellationToken)
    {
        var removido = await _fornecedorRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Fornecedor removido com sucesso." : "Fornecedor não encontrado."
        };
    }
}
