using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("id");
        builder.Property(u => u.Nome).HasColumnName("nome");
        builder.Property(u => u.Login).HasColumnName("usuario");
        builder.Property(u => u.Email).HasColumnName("email");
        builder.Property(u => u.Papel).HasColumnName("papel");
        builder.Property(u => u.Ativo).HasColumnName("ativo");
        builder.Property(u => u.SenhaHash).HasColumnName("senha_hash");
        builder.Property(u => u.CriadoEm).HasColumnName("criado_em").ValueGeneratedOnAdd();

        builder.HasIndex(u => u.Login).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
    }
}
