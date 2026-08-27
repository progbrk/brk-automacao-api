using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetFornecedorById;

public class GetFornecedorByIdQueryHandler : IRequestHandler<GetFornecedorByIdQuery, ResponseBase<Fornecedor>>
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public GetFornecedorByIdQueryHandler(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task<ResponseBase<Fornecedor>> Handle(GetFornecedorByIdQuery request, CancellationToken cancellationToken)
    {
        var fornecedor = await _fornecedorRepository.GetByIdAsync(request.Id);
        if (fornecedor is null)
        {
            return new ResponseBase<Fornecedor> { Success = false, Message = "Fornecedor não encontrado." };
        }

        return new ResponseBase<Fornecedor> { Data = fornecedor };
    }
}
