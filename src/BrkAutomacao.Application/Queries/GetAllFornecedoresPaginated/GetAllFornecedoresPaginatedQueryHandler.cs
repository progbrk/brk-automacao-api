using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Helpers;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Queries.GetAllFornecedoresPaginated;

public class GetAllFornecedoresPaginatedQueryHandler
    : IRequestHandler<GetAllFornecedoresPaginatedQuery, ResponseBase<PaginatedList<Fornecedor>>>
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public GetAllFornecedoresPaginatedQueryHandler(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task<ResponseBase<PaginatedList<Fornecedor>>> Handle(
        GetAllFornecedoresPaginatedQuery request, CancellationToken cancellationToken)
    {
        var pagina = await _fornecedorRepository.GetAllPaginatedAsync(request.PageIndex, request.PageSize);
        return new ResponseBase<PaginatedList<Fornecedor>> { Data = pagina };
    }
}
