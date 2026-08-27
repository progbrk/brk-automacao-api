using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateFornecedorCommand;

public class UpdateFornecedorCommandHandler : IRequestHandler<UpdateFornecedorCommand, ResponseBase<Fornecedor>>
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public UpdateFornecedorCommandHandler(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task<ResponseBase<Fornecedor>> Handle(UpdateFornecedorCommand request, CancellationToken cancellationToken)
    {
        var fornecedor = new Fornecedor
        {
            Id = request.Id,
            Nome = request.Nome,
            Contato = request.Contato,
            Telefone = request.Telefone,
            Email = request.Email,
            AtualizadoPor = request.UsuarioId
        };

        var atualizado = await _fornecedorRepository.UpdateAsync(fornecedor);
        if (atualizado is null)
        {
            return new ResponseBase<Fornecedor> { Success = false, Message = "Fornecedor não encontrado." };
        }

        return new ResponseBase<Fornecedor> { Data = atualizado, Message = "Fornecedor atualizado com sucesso." };
    }
}
