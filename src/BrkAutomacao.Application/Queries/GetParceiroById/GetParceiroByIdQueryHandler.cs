using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetParceiroById;

public class GetParceiroByIdQueryHandler : IRequestHandler<GetParceiroByIdQuery, ResponseBase<Parceiro>>
{
    private readonly IParceiroRepository _parceiroRepository;

    public GetParceiroByIdQueryHandler(IParceiroRepository parceiroRepository)
    {
        _parceiroRepository = parceiroRepository;
    }

    public async Task<ResponseBase<Parceiro>> Handle(GetParceiroByIdQuery request, CancellationToken cancellationToken)
    {
        var parceiro = await _parceiroRepository.GetByIdAsync(request.Id);
        if (parceiro is null)
        {
            return new ResponseBase<Parceiro> { Success = false, Message = "Parceiro não encontrado." };
        }

        return new ResponseBase<Parceiro> { Data = parceiro };
    }
}
