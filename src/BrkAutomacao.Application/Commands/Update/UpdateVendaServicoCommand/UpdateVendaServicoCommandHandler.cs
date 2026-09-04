using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateVendaServicoCommand;

public class UpdateVendaServicoCommandHandler : IRequestHandler<UpdateVendaServicoCommand, ResponseBase<VendaServico>>
{
    private readonly IVendaServicoRepository _vendaServicoRepository;

    public UpdateVendaServicoCommandHandler(IVendaServicoRepository vendaServicoRepository)
    {
        _vendaServicoRepository = vendaServicoRepository;
    }

    public async Task<ResponseBase<VendaServico>> Handle(UpdateVendaServicoCommand request, CancellationToken cancellationToken)
    {
        var item = new VendaServico
        {
            Id = request.Id,
            VendaId = request.VendaId,
            ServicoId = request.ServicoId,
            Quantidade = request.Quantidade,
            PrecoUnitario = request.PrecoUnitario,
            AtualizadoEm = DateTimeOffset.UtcNow,
            AtualizadoPor = request.UsuarioId,
        };

        var atualizado = await _vendaServicoRepository.UpdateAsync(item);
        if (atualizado is null)
        {
            return new ResponseBase<VendaServico> { Success = false, Message = "Serviço de venda não encontrado." };
        }

        return new ResponseBase<VendaServico> { Data = atualizado, Message = "Serviço de venda atualizado com sucesso." };
    }
}
