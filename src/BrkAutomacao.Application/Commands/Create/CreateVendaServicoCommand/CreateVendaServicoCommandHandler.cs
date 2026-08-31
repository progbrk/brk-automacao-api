using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateVendaServicoCommand;

public class CreateVendaServicoCommandHandler : IRequestHandler<CreateVendaServicoCommand, ResponseBase<VendaServico>>
{
    private readonly IVendaServicoRepository _vendaServicoRepository;

    public CreateVendaServicoCommandHandler(IVendaServicoRepository vendaServicoRepository)
    {
        _vendaServicoRepository = vendaServicoRepository;
    }

    public async Task<ResponseBase<VendaServico>> Handle(CreateVendaServicoCommand request, CancellationToken cancellationToken)
    {
        var item = new VendaServico
        {
            VendaId = request.VendaId,
            ServicoId = request.ServicoId,
            Quantidade = request.Quantidade,
            PrecoUnitario = request.PrecoUnitario,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _vendaServicoRepository.AddAsync(item);

        return new ResponseBase<VendaServico> { Data = criado, Message = "Serviço adicionado à venda com sucesso." };
    }
}
