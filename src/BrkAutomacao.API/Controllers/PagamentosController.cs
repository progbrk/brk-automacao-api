using System.Security.Claims;
using BrkAutomacao.Application.Commands.Create.CreatePagamentoCommand;
using BrkAutomacao.Application.Commands.Delete.DeletePagamentoCommand;
using BrkAutomacao.Application.Commands.Update.UpdatePagamentoCommand;
using BrkAutomacao.Application.Queries.GetAllPagamentosPaginated;
using BrkAutomacao.Application.Queries.GetPagamentoById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrkAutomacao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PagamentosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PagamentosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 20)
    {
        var response = await _mediator.Send(new GetAllPagamentosPaginatedQuery { PageIndex = pageIndex, PageSize = pageSize });
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetPagamentoByIdQuery(id));
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePagamentoCommand command)
    {
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Data?.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePagamentoCommand command)
    {
        command.Id = id;
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeletePagamentoCommand { Id = id });
        return response.Success ? Ok(response) : NotFound(response);
    }

    private Guid UsuarioIdAtual() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
