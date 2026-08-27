using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateFornecedorCommand;

public class CreateFornecedorCommandHandler : IRequestHandler<CreateFornecedorCommand, ResponseBase<Fornecedor>>
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public CreateFornecedorCommandHandler(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task<ResponseBase<Fornecedor>> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
    {
        var fornecedor = new Fornecedor
        {
            Nome = request.Nome,
            Contato = request.Contato,
            Telefone = request.Telefone,
            Email = request.Email,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _fornecedorRepository.AddAsync(fornecedor);

        return new ResponseBase<Fornecedor> { Data = criado, Message = "Fornecedor criado com sucesso." };
    }
}
