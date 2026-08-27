using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class ComissaoConfiguration : IEntityTypeConfiguration<Comissao>
{
    public void Configure(EntityTypeBuilder<Comissao> builder)
    {
        builder.ToTable("comissoes");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("id");
        builder.Property(c => c.ParceiroId).HasColumnName("parceiro_id");
        builder.Property(c => c.VendaId).HasColumnName("venda_id");
        builder.Property(c => c.Valor).HasColumnName("valor");
        builder.Property(c => c.Status).HasColumnName("status");
        builder.Property(c => c.DataPagamento).HasColumnName("data_pagamento");
        builder.Property(c => c.CriadoEm).HasColumnName("criado_em").ValueGeneratedOnAdd();
        builder.Property(c => c.AtualizadoEm).HasColumnName("atualizado_em").ValueGeneratedOnAddOrUpdate();
        builder.Property(c => c.CriadoPor).HasColumnName("criado_por");
        builder.Property(c => c.AtualizadoPor).HasColumnName("atualizado_por");

        builder.HasIndex(c => c.VendaId).IsUnique();
    }
}
