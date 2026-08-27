using BrkAutomacao.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrkAutomacao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseBase<string>>> Login(
        [FromBody] Application.Commands.Create.CreateLoginCommand.CreateLoginCommand command)
    {
        var response = await _mediator.Send(command);
        return response.Success ? Ok(response) : Unauthorized(response);
    }
}
