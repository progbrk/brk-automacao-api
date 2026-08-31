using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetPagamentoColaboradorById;

public class GetPagamentoColaboradorByIdQuery : IRequest<ResponseBase<PagamentoColaborador>>
{
    public Guid Id { get; set; }

    public GetPagamentoColaboradorByIdQuery(Guid id)
    {
        Id = id;
    }
}
