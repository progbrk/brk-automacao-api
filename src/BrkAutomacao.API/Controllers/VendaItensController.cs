using System.Security.Claims;
using BrkAutomacao.Application.Commands.Create.CreateVendaItemCommand;
using BrkAutomacao.Application.Commands.Delete.DeleteVendaItemCommand;
using BrkAutomacao.Application.Commands.Update.UpdateVendaItemCommand;
using BrkAutomacao.Application.Queries.GetAllVendaItensPaginated;
using BrkAutomacao.Application.Queries.GetVendaItemById;
using BrkAutomacao.Application.Queries.GetVendaItensByVenda;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrkAutomacao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VendaItensController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendaItensController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 20)
    {
        var response = await _mediator.Send(new GetAllVendaItensPaginatedQuery { PageIndex = pageIndex, PageSize = pageSize });
        return Ok(response);
    }

    [HttpGet("venda/{vendaId:guid}")]
    public async Task<IActionResult> GetByVenda(Guid vendaId)
    {
        var response = await _mediator.Send(new GetVendaItensByVendaQuery(vendaId));
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetVendaItemByIdQuery(id));
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVendaItemCommand command)
    {
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Data?.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVendaItemCommand command)
    {
        command.Id = id;
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteVendaItemCommand { Id = id });
        return response.Success ? Ok(response) : NotFound(response);
    }

    private Guid UsuarioIdAtual() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
