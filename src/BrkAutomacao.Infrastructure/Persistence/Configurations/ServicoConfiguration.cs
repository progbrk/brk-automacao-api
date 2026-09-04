using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.ToTable("servicos");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property(s => s.Nome).HasColumnName("nome");
        builder.Property(s => s.Descricao).HasColumnName("descricao");
        builder.Property(s => s.Preco).HasColumnName("preco");
        builder.Property(s => s.Ativo).HasColumnName("ativo");
        builder.Property(s => s.CriadoEm).HasColumnName("criado_em");
        builder.Property(s => s.AtualizadoEm).HasColumnName("atualizado_em");
        builder.Property(s => s.CriadoPor).HasColumnName("criado_por");
        builder.Property(s => s.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
