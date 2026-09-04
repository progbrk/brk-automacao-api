using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class VendaServicoConfiguration : IEntityTypeConfiguration<VendaServico>
{
    public void Configure(EntityTypeBuilder<VendaServico> builder)
    {
        builder.ToTable("venda_servicos");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.VendaId).HasColumnName("venda_id");
        builder.Property(i => i.ServicoId).HasColumnName("servico_id");
        builder.Property(i => i.Quantidade).HasColumnName("quantidade");
        builder.Property(i => i.PrecoUnitario).HasColumnName("preco_unitario");
        // GENERATED ALWAYS AS (quantidade * preco_unitario) STORED no Postgres.
        builder.Property(i => i.ValorTotal).HasColumnName("valor_total").ValueGeneratedOnAddOrUpdate();
        builder.Property(i => i.CriadoEm).HasColumnName("criado_em");
        builder.Property(i => i.AtualizadoEm).HasColumnName("atualizado_em");
        builder.Property(i => i.CriadoPor).HasColumnName("criado_por");
        builder.Property(i => i.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
