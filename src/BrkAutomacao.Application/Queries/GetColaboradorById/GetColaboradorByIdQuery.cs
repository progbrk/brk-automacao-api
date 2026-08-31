using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetColaboradorById;

public class GetColaboradorByIdQuery : IRequest<ResponseBase<Colaborador>>
{
    public Guid Id { get; set; }

    public GetColaboradorByIdQuery(Guid id)
    {
        Id = id;
    }
}
