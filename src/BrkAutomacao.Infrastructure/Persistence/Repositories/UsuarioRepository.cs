using BrkAutomacao.Core.Entities;
using BrkAutomacao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrkAutomacao.Infrastructure.Persistence.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetByLoginAsync(string login)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Login == login && u.Ativo);
    }
}
