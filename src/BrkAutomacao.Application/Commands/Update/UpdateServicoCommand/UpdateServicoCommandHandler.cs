using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateServicoCommand;

public class UpdateServicoCommandHandler : IRequestHandler<UpdateServicoCommand, ResponseBase<Servico>>
{
    private readonly IServicoRepository _servicoRepository;

    public UpdateServicoCommandHandler(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }

    public async Task<ResponseBase<Servico>> Handle(UpdateServicoCommand request, CancellationToken cancellationToken)
    {
        var servico = new Servico
        {
            Id = request.Id,
            Nome = request.Nome,
            Descricao = request.Descricao,
            Preco = request.Preco,
            Ativo = request.Ativo,
            AtualizadoPor = request.UsuarioId
        };

        var atualizado = await _servicoRepository.UpdateAsync(servico);
        if (atualizado is null)
        {
            return new ResponseBase<Servico> { Success = false, Message = "Serviço não encontrado." };
        }

        return new ResponseBase<Servico> { Data = atualizado, Message = "Serviço atualizado com sucesso." };
    }
}
