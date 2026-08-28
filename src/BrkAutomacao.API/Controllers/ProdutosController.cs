using System.Security.Claims;
using BrkAutomacao.Application.Commands.Create.CreateProdutoCommand;
using BrkAutomacao.Application.Commands.Delete.DeleteProdutoCommand;
using BrkAutomacao.Application.Commands.Update.AtualizarFotoProdutoCommand;
using BrkAutomacao.Application.Commands.Update.UpdateProdutoCommand;
using BrkAutomacao.Application.Queries.GetAllProdutosPaginated;
using BrkAutomacao.Application.Queries.GetProdutoById;
using BrkAutomacao.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrkAutomacao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProdutosController : ControllerBase
{
    private static readonly Dictionary<string, string> ExtensoesValidas = new()
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/webp"] = ".webp"
    };

    private const long TamanhoMaximoBytes = 5 * 1024 * 1024;

    private readonly IMediator _mediator;
    private readonly IWebHostEnvironment _ambiente;

    public ProdutosController(IMediator mediator, IWebHostEnvironment ambiente)
    {
        _mediator = mediator;
        _ambiente = ambiente;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 20)
    {
        var response = await _mediator.Send(new GetAllProdutosPaginatedQuery { PageIndex = pageIndex, PageSize = pageSize });
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetProdutoByIdQuery(id));
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProdutoCommand command)
    {
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Data?.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProdutoCommand command)
    {
        command.Id = id;
        command.UsuarioId = UsuarioIdAtual();
        var response = await _mediator.Send(command);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteProdutoCommand { Id = id });
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost("{id:guid}/foto")]
    [RequestSizeLimit(TamanhoMaximoBytes)]
    public async Task<IActionResult> UploadFoto(Guid id, IFormFile arquivo)
    {
        if (arquivo.Length == 0)
        {
            return BadRequest(new ResponseBase<object> { Success = false, Message = "Arquivo vazio." });
        }

        if (arquivo.Length > TamanhoMaximoBytes)
        {
            return BadRequest(new ResponseBase<object> { Success = false, Message = "Arquivo maior que 5MB." });
        }

        if (!ExtensoesValidas.TryGetValue(arquivo.ContentType, out var extensao))
        {
            return BadRequest(new ResponseBase<object> { Success = false, Message = "Formato inválido. Use JPEG, PNG ou WEBP." });
        }

        var pastaUploads = Path.Combine(_ambiente.ContentRootPath, "wwwroot", "uploads", "produtos");
        Directory.CreateDirectory(pastaUploads);

        foreach (var arquivoAntigo in Directory.EnumerateFiles(pastaUploads, $"{id}.*"))
        {
            System.IO.File.Delete(arquivoAntigo);
        }

        var caminhoArquivo = Path.Combine(pastaUploads, $"{id}{extensao}");
        await using (var stream = System.IO.File.Create(caminhoArquivo))
        {
            await arquivo.CopyToAsync(stream);
        }

        var fotoUrl = $"/uploads/produtos/{id}{extensao}";
        var response = await _mediator.Send(new AtualizarFotoProdutoCommand { Id = id, FotoUrl = fotoUrl, UsuarioId = UsuarioIdAtual() });
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id:guid}/foto")]
    public async Task<IActionResult> RemoverFoto(Guid id)
    {
        var pastaUploads = Path.Combine(_ambiente.ContentRootPath, "wwwroot", "uploads", "produtos");
        if (Directory.Exists(pastaUploads))
        {
            foreach (var arquivoAntigo in Directory.EnumerateFiles(pastaUploads, $"{id}.*"))
            {
                System.IO.File.Delete(arquivoAntigo);
            }
        }

        var response = await _mediator.Send(new AtualizarFotoProdutoCommand { Id = id, FotoUrl = null, UsuarioId = UsuarioIdAtual() });
        return response.Success ? Ok(response) : NotFound(response);
    }

    private Guid UsuarioIdAtual() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
