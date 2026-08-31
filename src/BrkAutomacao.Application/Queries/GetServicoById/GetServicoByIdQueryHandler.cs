using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetServicoById;

public class GetServicoByIdQueryHandler : IRequestHandler<GetServicoByIdQuery, ResponseBase<Servico>>
{
    private readonly IServicoRepository _servicoRepository;

    public GetServicoByIdQueryHandler(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }

    public async Task<ResponseBase<Servico>> Handle(GetServicoByIdQuery request, CancellationToken cancellationToken)
    {
        var servico = await _servicoRepository.GetByIdAsync(request.Id);
        if (servico is null)
        {
            return new ResponseBase<Servico> { Success = false, Message = "Serviço não encontrado." };
        }

        return new ResponseBase<Servico> { Data = servico };
    }
}
