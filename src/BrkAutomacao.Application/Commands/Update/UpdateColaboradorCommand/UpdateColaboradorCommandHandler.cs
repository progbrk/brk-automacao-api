using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateColaboradorCommand;

public class UpdateColaboradorCommandHandler : IRequestHandler<UpdateColaboradorCommand, ResponseBase<Colaborador>>
{
    private readonly IColaboradorRepository _colaboradorRepository;

    public UpdateColaboradorCommandHandler(IColaboradorRepository colaboradorRepository)
    {
        _colaboradorRepository = colaboradorRepository;
    }

    public async Task<ResponseBase<Colaborador>> Handle(UpdateColaboradorCommand request, CancellationToken cancellationToken)
    {
        var colaborador = new Colaborador
        {
            Id = request.Id,
            Nome = request.Nome,
            Cargo = request.Cargo,
            Telefone = request.Telefone,
            Email = request.Email,
            Ativo = request.Ativo,
            AtualizadoEm = DateTimeOffset.UtcNow,
            AtualizadoPor = request.UsuarioId,
        };

        var atualizado = await _colaboradorRepository.UpdateAsync(colaborador);
        if (atualizado is null)
        {
            return new ResponseBase<Colaborador> { Success = false, Message = "Colaborador não encontrado." };
        }

        return new ResponseBase<Colaborador> { Data = atualizado, Message = "Colaborador atualizado com sucesso." };
    }
}
