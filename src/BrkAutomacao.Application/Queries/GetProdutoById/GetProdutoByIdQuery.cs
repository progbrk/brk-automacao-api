using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetProdutoById;

public class GetProdutoByIdQuery : IRequest<ResponseBase<Produto>>
{
    public Guid Id { get; set; }

    public GetProdutoByIdQuery(Guid id)
    {
        Id = id;
    }
}
