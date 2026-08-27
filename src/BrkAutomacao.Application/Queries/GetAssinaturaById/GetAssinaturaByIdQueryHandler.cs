using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAssinaturaById;

public class GetAssinaturaByIdQueryHandler : IRequestHandler<GetAssinaturaByIdQuery, ResponseBase<Assinatura>>
{
    private readonly IAssinaturaRepository _assinaturaRepository;

    public GetAssinaturaByIdQueryHandler(IAssinaturaRepository assinaturaRepository)
    {
        _assinaturaRepository = assinaturaRepository;
    }

    public async Task<ResponseBase<Assinatura>> Handle(GetAssinaturaByIdQuery request, CancellationToken cancellationToken)
    {
        var assinatura = await _assinaturaRepository.GetByIdAsync(request.Id);
        if (assinatura is null)
        {
            return new ResponseBase<Assinatura> { Success = false, Message = "Assinatura não encontrada." };
        }

        return new ResponseBase<Assinatura> { Data = assinatura };
    }
}
