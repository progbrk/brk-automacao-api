using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.ToTable("fornecedores");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id).HasColumnName("id");
        builder.Property(f => f.Nome).HasColumnName("nome");
        builder.Property(f => f.Contato).HasColumnName("contato");
        builder.Property(f => f.Telefone).HasColumnName("telefone");
        builder.Property(f => f.Email).HasColumnName("email");
        builder.Property(f => f.CriadoEm).HasColumnName("criado_em").ValueGeneratedOnAdd();
        builder.Property(f => f.AtualizadoEm).HasColumnName("atualizado_em").ValueGeneratedOnAddOrUpdate();
        builder.Property(f => f.CriadoPor).HasColumnName("criado_por");
        builder.Property(f => f.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
