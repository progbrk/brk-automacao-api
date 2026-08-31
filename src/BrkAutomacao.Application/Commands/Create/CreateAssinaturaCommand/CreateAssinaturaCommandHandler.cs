using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateAssinaturaCommand;

public class CreateAssinaturaCommandHandler : IRequestHandler<CreateAssinaturaCommand, ResponseBase<Assinatura>>
{
    private readonly IAssinaturaRepository _assinaturaRepository;

    public CreateAssinaturaCommandHandler(IAssinaturaRepository assinaturaRepository)
    {
        _assinaturaRepository = assinaturaRepository;
    }

    public async Task<ResponseBase<Assinatura>> Handle(CreateAssinaturaCommand request, CancellationToken cancellationToken)
    {
        var assinatura = new Assinatura
        {
            ClienteId = request.ClienteId,
            VendaId = request.VendaId,
            PlanoId = request.PlanoId,
            ValorMensal = request.ValorMensal,
            DiaCobranca = request.DiaCobranca,
            Status = request.Status,
            DataInicio = request.DataInicio ?? DateOnly.FromDateTime(DateTime.UtcNow),
            DataFim = request.DataFim,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criada = await _assinaturaRepository.AddAsync(assinatura);

        return new ResponseBase<Assinatura> { Data = criada, Message = "Assinatura criada com sucesso." };
    }
}
