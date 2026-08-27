using BrkAutomacao.Core.Responses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BrkAutomacao.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new ResponseBase<object>
            {
                Success = false,
                Message = string.Join(" | ", ex.Errors.Select(e => e.ErrorMessage))
            });
        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException pg)
        {
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            await context.Response.WriteAsJsonAsync(new ResponseBase<object>
            {
                Success = false,
                Message = pg.SqlState switch
                {
                    "23503" => "Não é possível concluir: existe(m) registro(s) vinculado(s) a este item.",
                    "23505" => "Já existe um registro com esse valor único.",
                    _ => "Não foi possível concluir a operação no banco de dados."
                }
            });
        }
    }
}
