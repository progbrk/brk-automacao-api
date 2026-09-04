using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        builder.ToTable("pagamentos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.ClienteId).HasColumnName("cliente_id");
        builder.Property(p => p.VendaId).HasColumnName("venda_id");
        builder.Property(p => p.AssinaturaId).HasColumnName("assinatura_id");
        builder.Property(p => p.Valor).HasColumnName("valor");
        builder.Property(p => p.FormaPagamento).HasColumnName("forma_pagamento");
        builder.Property(p => p.Status).HasColumnName("status");
        builder.Property(p => p.DataPagamento).HasColumnName("data_pagamento");
        builder.Property(p => p.CriadoEm).HasColumnName("criado_em");
        builder.Property(p => p.AtualizadoEm).HasColumnName("atualizado_em");
        builder.Property(p => p.CriadoPor).HasColumnName("criado_por");
        builder.Property(p => p.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
