using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.ToTable("compras");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("id");
        builder.Property(c => c.FornecedorId).HasColumnName("fornecedor_id");
        builder.Property(c => c.VendaId).HasColumnName("venda_id");
        builder.Property(c => c.Item).HasColumnName("item");
        builder.Property(c => c.Quantidade).HasColumnName("quantidade");
        builder.Property(c => c.ValorUnitario).HasColumnName("valor_unitario");
        builder.Property(c => c.Frete).HasColumnName("frete");
        builder.Property(c => c.Imposto).HasColumnName("imposto");
        // Colunas GENERATED ALWAYS AS ... STORED no Postgres — calculadas pelo banco,
        // nunca enviadas em INSERT/UPDATE.
        builder.Property(c => c.ValorTotal).HasColumnName("valor_total").ValueGeneratedOnAddOrUpdate();
        builder.Property(c => c.ValorTotalComEncargos).HasColumnName("valor_total_com_encargos").ValueGeneratedOnAddOrUpdate();
        builder.Property(c => c.DataCompra).HasColumnName("data_compra");
        builder.Property(c => c.CriadoEm).HasColumnName("criado_em").ValueGeneratedOnAdd();
        builder.Property(c => c.AtualizadoEm).HasColumnName("atualizado_em").ValueGeneratedOnAddOrUpdate();
        builder.Property(c => c.CriadoPor).HasColumnName("criado_por");
        builder.Property(c => c.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
