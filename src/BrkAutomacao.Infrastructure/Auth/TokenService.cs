using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BrkAutomacao.Infrastructure.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GerarToken(Usuario usuario)
    {
        var chaveSecreta = _configuration["Jwt:SecretKey"]
            ?? throw new InvalidOperationException("Configuração ausente: Jwt:SecretKey.");
        var horasExpiracao = _configuration.GetValue<double?>("Jwt:ExpiraHoras") ?? 8;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new(ClaimTypes.Name, usuario.Login),
            new("nome", usuario.Nome),
            new("papel", usuario.Papel)
        };
        if (!string.IsNullOrWhiteSpace(usuario.Email))
        {
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(horasExpiracao),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
