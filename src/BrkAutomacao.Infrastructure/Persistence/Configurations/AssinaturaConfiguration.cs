using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class AssinaturaConfiguration : IEntityTypeConfiguration<Assinatura>
{
    public void Configure(EntityTypeBuilder<Assinatura> builder)
    {
        builder.ToTable("assinaturas");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("id");
        builder.Property(a => a.ClienteId).HasColumnName("cliente_id");
        builder.Property(a => a.VendaId).HasColumnName("venda_id");
        builder.Property(a => a.ValorMensal).HasColumnName("valor_mensal");
        builder.Property(a => a.DiaCobranca).HasColumnName("dia_cobranca");
        builder.Property(a => a.Status).HasColumnName("status");
        builder.Property(a => a.DataInicio).HasColumnName("data_inicio");
        builder.Property(a => a.DataFim).HasColumnName("data_fim");
        builder.Property(a => a.CriadoEm).HasColumnName("criado_em").ValueGeneratedOnAdd();
        builder.Property(a => a.AtualizadoEm).HasColumnName("atualizado_em").ValueGeneratedOnAddOrUpdate();
        builder.Property(a => a.CriadoPor).HasColumnName("criado_por");
        builder.Property(a => a.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
