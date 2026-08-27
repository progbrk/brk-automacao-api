using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using BrkAutomacao.Core.Responses;
using MediatR;

namespace BrkAutomacao.Application.Commands.Create.CreateParceiroCommand;

public class CreateParceiroCommandHandler : IRequestHandler<CreateParceiroCommand, ResponseBase<Parceiro>>
{
    private readonly IParceiroRepository _parceiroRepository;

    public CreateParceiroCommandHandler(IParceiroRepository parceiroRepository)
    {
        _parceiroRepository = parceiroRepository;
    }

    public async Task<ResponseBase<Parceiro>> Handle(CreateParceiroCommand request, CancellationToken cancellationToken)
    {
        var parceiro = new Parceiro
        {
            Nome = request.Nome,
            Tipo = request.Tipo,
            Telefone = request.Telefone,
            Email = request.Email,
            PercentualComissao = request.PercentualComissao,
            CriadoPor = request.UsuarioId,
            AtualizadoPor = request.UsuarioId
        };

        var criado = await _parceiroRepository.AddAsync(parceiro);

        return new ResponseBase<Parceiro> { Data = criado, Message = "Parceiro criado com sucesso." };
    }
}
