using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Delete.DeleteServicoCommand;

public class DeleteServicoCommandHandler : IRequestHandler<DeleteServicoCommand, ResponseBase<bool>>
{
    private readonly IServicoRepository _servicoRepository;

    public DeleteServicoCommandHandler(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }

    public async Task<ResponseBase<bool>> Handle(DeleteServicoCommand request, CancellationToken cancellationToken)
    {
        var removido = await _servicoRepository.DeleteAsync(request.Id);
        return new ResponseBase<bool>
        {
            Success = removido,
            Data = removido,
            Message = removido ? "Serviço removido com sucesso." : "Serviço não encontrado."
        };
    }
}
