using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class PlanoAssinaturaConfiguration : IEntityTypeConfiguration<PlanoAssinatura>
{
    public void Configure(EntityTypeBuilder<PlanoAssinatura> builder)
    {
        builder.ToTable("planos_assinatura");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Nome).HasColumnName("nome");
        builder.Property(p => p.Descricao).HasColumnName("descricao");
        builder.Property(p => p.ValorMensal).HasColumnName("valor_mensal");
        builder.Property(p => p.Ativo).HasColumnName("ativo");
        builder.Property(p => p.CriadoEm).HasColumnName("criado_em");
        builder.Property(p => p.AtualizadoEm).HasColumnName("atualizado_em");
        builder.Property(p => p.CriadoPor).HasColumnName("criado_por");
        builder.Property(p => p.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
