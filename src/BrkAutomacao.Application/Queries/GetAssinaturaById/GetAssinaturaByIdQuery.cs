using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAssinaturaById;

public class GetAssinaturaByIdQuery : IRequest<ResponseBase<Assinatura>>
{
    public Guid Id { get; set; }

    public GetAssinaturaByIdQuery(Guid id)
    {
        Id = id;
    }
}
