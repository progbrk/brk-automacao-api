using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Update.UpdateParceiroCommand;

public class UpdateParceiroCommandHandler : IRequestHandler<UpdateParceiroCommand, ResponseBase<Parceiro>>
{
    private readonly IParceiroRepository _parceiroRepository;

    public UpdateParceiroCommandHandler(IParceiroRepository parceiroRepository)
    {
        _parceiroRepository = parceiroRepository;
    }

    public async Task<ResponseBase<Parceiro>> Handle(UpdateParceiroCommand request, CancellationToken cancellationToken)
    {
        var parceiro = new Parceiro
        {
            Id = request.Id,
            Nome = request.Nome,
            Tipo = request.Tipo,
            Telefone = request.Telefone,
            Email = request.Email,
            PercentualComissao = request.PercentualComissao,
            AtualizadoEm = DateTimeOffset.UtcNow,
            AtualizadoPor = request.UsuarioId,
        };

        var atualizado = await _parceiroRepository.UpdateAsync(parceiro);
        if (atualizado is null)
        {
            return new ResponseBase<Parceiro> { Success = false, Message = "Parceiro não encontrado." };
        }

        return new ResponseBase<Parceiro> { Data = atualizado, Message = "Parceiro atualizado com sucesso." };
    }
}
