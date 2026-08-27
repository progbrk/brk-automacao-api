using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteComissaoCommand;

public class DeleteComissaoCommandHandler : IRequestHandler<DeleteComissaoCommand, ResponseBase<bool>>
{
    private readonly IComissaoRepository _comissaoRepository;

    public DeleteComissaoCommandHandler(IComissaoRepository comissaoRepository)
    {
        _comissaoRepository = comissaoRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteComissaoCommand request, CancellationToken cancellationToken)
    {
        var removida = await _comissaoRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removida,
            Data = removida,
            Message = removida ? "Comissão removida com sucesso." : "Comissão não encontrada."
        };
    }
}
