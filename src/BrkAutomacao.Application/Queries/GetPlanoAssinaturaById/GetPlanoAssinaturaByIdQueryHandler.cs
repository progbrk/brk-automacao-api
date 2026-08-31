using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetPlanoAssinaturaById;

public class GetPlanoAssinaturaByIdQueryHandler : IRequestHandler<GetPlanoAssinaturaByIdQuery, ResponseBase<PlanoAssinatura>>
{
    private readonly IPlanoAssinaturaRepository _planoAssinaturaRepository;

    public GetPlanoAssinaturaByIdQueryHandler(IPlanoAssinaturaRepository planoAssinaturaRepository)
    {
        _planoAssinaturaRepository = planoAssinaturaRepository;
    }

    public async Task<ResponseBase<PlanoAssinatura>> Handle(GetPlanoAssinaturaByIdQuery request, CancellationToken cancellationToken)
    {
        var plano = await _planoAssinaturaRepository.GetByIdAsync(request.Id);
        if (plano is null)
        {
            return new ResponseBase<PlanoAssinatura> { Success = false, Message = "Plano de assinatura não encontrado." };
        }

        return new ResponseBase<PlanoAssinatura> { Data = plano };
    }
}
