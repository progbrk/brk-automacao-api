using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class VendaItemConfiguration : IEntityTypeConfiguration<VendaItem>
{
    public void Configure(EntityTypeBuilder<VendaItem> builder)
    {
        builder.ToTable("venda_itens");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.VendaId).HasColumnName("venda_id");
        builder.Property(i => i.ProdutoId).HasColumnName("produto_id");
        builder.Property(i => i.Quantidade).HasColumnName("quantidade");
        builder.Property(i => i.PrecoUnitario).HasColumnName("preco_unitario");
        // GENERATED ALWAYS AS (quantidade * preco_unitario) STORED no Postgres.
        builder.Property(i => i.ValorTotal).HasColumnName("valor_total").ValueGeneratedOnAddOrUpdate();
        builder.Property(i => i.CriadoEm).HasColumnName("criado_em").ValueGeneratedOnAdd();
        builder.Property(i => i.AtualizadoEm).HasColumnName("atualizado_em").ValueGeneratedOnAddOrUpdate();
        builder.Property(i => i.CriadoPor).HasColumnName("criado_por");
        builder.Property(i => i.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
