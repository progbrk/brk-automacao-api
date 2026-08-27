using System.Security.Claims;
using BrkAutomacao.Application.Commands.Create.CreateParceiroCommand;
using BrkAutomacao.Application.Commands.Delete.DeleteParceiroCommand;
using BrkAutomacao.Application.Commands.Update.UpdateParceiroCommand;
using BrkAutomacao.Application.Queries.GetAllParceirosPaginated;
using BrkAutomacao.Application.Queries.GetParceiroById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrkAutomacao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ParceirosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParceirosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 20)
    {
        var response = await _mediator.Send(new GetAllParceirosPaginatedQuery { PageIndex = pageIndex, PageSize = pageSize });
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetParceiroByIdQuery(id));
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateParceiroCommand command)
    {
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Data?.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateParceiroCommand command)
    {
        command.Id = id;
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteParceiroCommand { Id = id });
        return response.Success ? Ok(response) : NotFound(response);
    }

    private Guid UsuarioIdAtual() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
