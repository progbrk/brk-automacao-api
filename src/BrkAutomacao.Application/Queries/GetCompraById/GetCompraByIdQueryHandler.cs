using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetCompraById;

public class GetCompraByIdQueryHandler : IRequestHandler<GetCompraByIdQuery, ResponseBase<Compra>>
{
    private readonly ICompraRepository _compraRepository;

    public GetCompraByIdQueryHandler(ICompraRepository compraRepository)
    {
        _compraRepository = compraRepository;
    }

    public async Task<ResponseBase<Compra>> Handle(GetCompraByIdQuery request, CancellationToken cancellationToken)
    {
        var compra = await _compraRepository.GetByIdAsync(request.Id);
        if (compra is null)
        {
            return new ResponseBase<Compra> { Success = false, Message = "Compra não encontrada." };
        }

        return new ResponseBase<Compra> { Data = compra };
    }
}
