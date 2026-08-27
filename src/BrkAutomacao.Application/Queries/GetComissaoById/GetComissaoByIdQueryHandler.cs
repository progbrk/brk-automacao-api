using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetComissaoById;

public class GetComissaoByIdQueryHandler : IRequestHandler<GetComissaoByIdQuery, ResponseBase<Comissao>>
{
    private readonly IComissaoRepository _comissaoRepository;

    public GetComissaoByIdQueryHandler(IComissaoRepository comissaoRepository)
    {
        _comissaoRepository = comissaoRepository;
    }

    public async Task<ResponseBase<Comissao>> Handle(GetComissaoByIdQuery request, CancellationToken cancellationToken)
    {
        var comissao = await _comissaoRepository.GetByIdAsync(request.Id);
        if (comissao is null)
        {
            return new ResponseBase<Comissao> { Success = false, Message = "Comissão não encontrada." };
        }

        return new ResponseBase<Comissao> { Data = comissao };
    }
}
