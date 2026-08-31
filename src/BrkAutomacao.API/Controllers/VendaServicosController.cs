using System.Security.Claims;
using BrkAutomacao.Application.Commands.Create.CreateVendaServicoCommand;
using BrkAutomacao.Application.Commands.Delete.DeleteVendaServicoCommand;
using BrkAutomacao.Application.Commands.Update.UpdateVendaServicoCommand;
using BrkAutomacao.Application.Queries.GetAllVendaServicosPaginated;
using BrkAutomacao.Application.Queries.GetVendaServicoById;
using BrkAutomacao.Application.Queries.GetVendaServicosByVenda;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrkAutomacao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VendaServicosController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendaServicosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 20)
    {
        var response = await _mediator.Send(new GetAllVendaServicosPaginatedQuery { PageIndex = pageIndex, PageSize = pageSize });
        return Ok(response);
    }

    [HttpGet("venda/{vendaId:guid}")]
    public async Task<IActionResult> GetByVenda(Guid vendaId)
    {
        var response = await _mediator.Send(new GetVendaServicosByVendaQuery(vendaId));
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetVendaServicoByIdQuery(id));
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVendaServicoCommand command)
    {
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Data?.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVendaServicoCommand command)
    {
        command.Id = id;
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteVendaServicoCommand { Id = id });
        return response.Success ? Ok(response) : NotFound(response);
    }

    private Guid UsuarioIdAtual() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
