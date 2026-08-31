using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetColaboradorById;

public class GetColaboradorByIdQueryHandler : IRequestHandler<GetColaboradorByIdQuery, ResponseBase<Colaborador>>
{
    private readonly IColaboradorRepository _colaboradorRepository;

    public GetColaboradorByIdQueryHandler(IColaboradorRepository colaboradorRepository)
    {
        _colaboradorRepository = colaboradorRepository;
    }

    public async Task<ResponseBase<Colaborador>> Handle(GetColaboradorByIdQuery request, CancellationToken cancellationToken)
    {
        var colaborador = await _colaboradorRepository.GetByIdAsync(request.Id);
        if (colaborador is null)
        {
            return new ResponseBase<Colaborador> { Success = false, Message = "Colaborador não encontrado." };
        }

        return new ResponseBase<Colaborador> { Data = colaborador };
    }
}
