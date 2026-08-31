using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateServicoCommand;

public class CreateServicoCommandHandler : IRequestHandler<CreateServicoCommand, ResponseBase<Servico>>
{
    private readonly IServicoRepository _servicoRepository;

    public CreateServicoCommandHandler(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }

    public async Task<ResponseBase<Servico>> Handle(CreateServicoCommand request, CancellationToken cancellationToken)
    {
        var servico = new Servico
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            Preco = request.Preco,
            Ativo = request.Ativo,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _servicoRepository.AddAsync(servico);

        return new ResponseBase<Servico> { Data = criado, Message = "Serviço criado com sucesso." };
    }
}
