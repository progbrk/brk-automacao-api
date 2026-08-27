using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetPagamentoById;

public class GetPagamentoByIdQuery : IRequest<ResponseBase<Pagamento>>
{
    public Guid Id { get; set; }

    public GetPagamentoByIdQuery(Guid id)
    {
        Id = id;
    }
}
