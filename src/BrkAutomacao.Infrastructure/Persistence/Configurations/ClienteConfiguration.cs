using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("clientes");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("id");
        builder.Property(c => c.Nome).HasColumnName("nome");
        builder.Property(c => c.CpfCnpj).HasColumnName("cpf_cnpj");
        builder.Property(c => c.Telefone).HasColumnName("telefone");
        builder.Property(c => c.Email).HasColumnName("email");
        builder.Property(c => c.Endereco).HasColumnName("endereco");
        builder.Property(c => c.Cidade).HasColumnName("cidade");
        builder.Property(c => c.Estado).HasColumnName("estado");
        builder.Property(c => c.Cep).HasColumnName("cep");
        builder.Property(c => c.Observacoes).HasColumnName("observacoes");
        builder.Property(c => c.CriadoEm).HasColumnName("criado_em").ValueGeneratedOnAdd();
        builder.Property(c => c.AtualizadoEm).HasColumnName("atualizado_em").ValueGeneratedOnAddOrUpdate();
        builder.Property(c => c.CriadoPor).HasColumnName("criado_por");
        builder.Property(c => c.AtualizadoPor).HasColumnName("atualizado_por");

        builder.HasIndex(c => c.CpfCnpj).IsUnique();
    }
}
