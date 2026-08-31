using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetPlanoAssinaturaById;

public class GetPlanoAssinaturaByIdQuery : IRequest<ResponseBase<PlanoAssinatura>>
{
    public Guid Id { get; set; }

    public GetPlanoAssinaturaByIdQuery(Guid id)
    {
        Id = id;
    }
}
