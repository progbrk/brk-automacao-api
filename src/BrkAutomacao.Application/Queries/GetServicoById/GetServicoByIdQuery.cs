using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetServicoById;

public class GetServicoByIdQuery : IRequest<ResponseBase<Servico>>
{
    public Guid Id { get; set; }

    public GetServicoByIdQuery(Guid id)
    {
        Id = id;
    }
}
