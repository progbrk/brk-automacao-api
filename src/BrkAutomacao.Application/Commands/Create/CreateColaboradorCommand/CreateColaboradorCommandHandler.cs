using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateColaboradorCommand;

public class CreateColaboradorCommandHandler : IRequestHandler<CreateColaboradorCommand, ResponseBase<Colaborador>>
{
    private readonly IColaboradorRepository _colaboradorRepository;

    public CreateColaboradorCommandHandler(IColaboradorRepository colaboradorRepository)
    {
        _colaboradorRepository = colaboradorRepository;
    }

    public async Task<ResponseBase<Colaborador>> Handle(CreateColaboradorCommand request, CancellationToken cancellationToken)
    {
        var colaborador = new Colaborador
        {
            Nome = request.Nome,
            Cargo = request.Cargo,
            Telefone = request.Telefone,
            Email = request.Email,
            Ativo = request.Ativo,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _colaboradorRepository.AddAsync(colaborador);

        return new ResponseBase<Colaborador> { Data = criado, Message = "Colaborador criado com sucesso." };
    }
}
