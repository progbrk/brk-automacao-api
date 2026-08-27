using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetComissaoById;

public class GetComissaoByIdQuery : IRequest<ResponseBase<Comissao>>
{
    public Guid Id { get; set; }

    public GetComissaoByIdQuery(Guid id)
    {
        Id = id;
    }
}
