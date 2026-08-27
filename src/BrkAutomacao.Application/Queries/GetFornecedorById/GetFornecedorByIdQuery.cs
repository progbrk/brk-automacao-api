using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetFornecedorById;

public class GetFornecedorByIdQuery : IRequest<ResponseBase<Fornecedor>>
{
    public Guid Id { get; set; }

    public GetFornecedorByIdQuery(Guid id)
    {
        Id = id;
    }
}
