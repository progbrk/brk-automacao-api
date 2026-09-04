using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateVendaCommand;

public class CreateVendaCommandHandler : IRequestHandler<CreateVendaCommand, ResponseBase<Venda>>
{
    private readonly IVendaRepository _vendaRepository;

    public CreateVendaCommandHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<ResponseBase<Venda>> Handle(CreateVendaCommand request, CancellationToken cancellationToken)
    {
        var venda = new Venda
        {
            ClienteId = request.ClienteId,
            ParceiroId = request.ParceiroId,
            Descricao = request.Descricao,
            Desconto = request.Desconto,
            Status = request.Status,
            DataVenda = request.DataVenda ?? DateOnly.FromDateTime(DateTime.UtcNow),
            CriadoEm = DateTimeOffset.UtcNow,
            AtualizadoEm = DateTimeOffset.UtcNow,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criada = await _vendaRepository.AddAsync(venda);

        return new ResponseBase<Venda> { Data = criada, Message = "Venda criada com sucesso." };
    }
}
