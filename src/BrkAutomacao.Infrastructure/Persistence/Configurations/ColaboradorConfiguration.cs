using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
{
    public void Configure(EntityTypeBuilder<Colaborador> builder)
    {
        builder.ToTable("colaboradores");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("id");
        builder.Property(c => c.Nome).HasColumnName("nome");
        builder.Property(c => c.Cargo).HasColumnName("cargo");
        builder.Property(c => c.Telefone).HasColumnName("telefone");
        builder.Property(c => c.Email).HasColumnName("email");
        builder.Property(c => c.Ativo).HasColumnName("ativo");
        builder.Property(c => c.CriadoEm).HasColumnName("criado_em").ValueGeneratedOnAdd();
        builder.Property(c => c.AtualizadoEm).HasColumnName("atualizado_em").ValueGeneratedOnAddOrUpdate();
        builder.Property(c => c.CriadoPor).HasColumnName("criado_por");
        builder.Property(c => c.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
