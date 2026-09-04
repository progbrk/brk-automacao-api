using System.Security.Claims;
using BrkAutomacao.Application.Commands.Create.CreateEquipamentoCommand;
using BrkAutomacao.Application.Commands.Delete.DeleteEquipamentoCommand;
using BrkAutomacao.Application.Commands.Update.UpdateEquipamentoCommand;
using BrkAutomacao.Application.Queries.GetAllEquipamentosPaginated;
using BrkAutomacao.Application.Queries.GetEquipamentoById;
using BrkAutomacao.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrkAutomacao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EquipamentosController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IEquipamentoRepository _equipamentoRepository;

    public EquipamentosController(IMediator mediator, IEquipamentoRepository equipamentoRepository)
    {
        _mediator = mediator;
        _equipamentoRepository = equipamentoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 20)
    {
        var response = await _mediator.Send(new GetAllEquipamentosPaginatedQuery { PageIndex = pageIndex, PageSize = pageSize });
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetEquipamentoByIdQuery(id));
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEquipamentoCommand command)
    {
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Data?.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEquipamentoCommand command)
    {
        command.Id = id;
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteEquipamentoCommand { Id = id });
        return response.Success ? Ok(response) : NotFound(response);
    }

    /// <summary>
    /// Token de conexão do Equipamento (ex: access token do Home Assistant) — nunca sai
    /// pelo GetAll/GetById normal (Token é [JsonIgnore] na entidade). Só a conta técnica
    /// de sistema (papel "sistema") pode ler, pra importar/conectar de fora (srv-brk-client).
    /// </summary>
    [HttpGet("{id:guid}/token")]
    public async Task<IActionResult> ObterToken(Guid id)
    {
        if (User.FindFirstValue("papel") != "sistema")
            return Forbid();

        var equipamento = await _equipamentoRepository.GetByIdAsync(id);
        if (equipamento is null)
            return NotFound();

        return Ok(new { token = equipamento.Token });
    }

    private Guid UsuarioIdAtual() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
