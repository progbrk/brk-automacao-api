using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class VendaConfiguration : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.ToTable("vendas");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id).HasColumnName("id");
        builder.Property(v => v.ClienteId).HasColumnName("cliente_id");
        builder.Property(v => v.ParceiroId).HasColumnName("parceiro_id");
        builder.Property(v => v.Descricao).HasColumnName("descricao");
        builder.Property(v => v.Desconto).HasColumnName("desconto");
        // Não existe coluna "valor" no banco — é calculado em VendaRepository a partir de
        // VendaItens + VendaServicos, menos Desconto.
        builder.Ignore(v => v.Valor);
        builder.Property(v => v.Status).HasColumnName("status");
        builder.Property(v => v.DataVenda).HasColumnName("data_venda");
        builder.Property(v => v.CriadoEm).HasColumnName("criado_em");
        builder.Property(v => v.AtualizadoEm).HasColumnName("atualizado_em");
        builder.Property(v => v.CriadoPor).HasColumnName("criado_por");
        builder.Property(v => v.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
