using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class PagamentoColaboradorConfiguration : IEntityTypeConfiguration<PagamentoColaborador>
{
    public void Configure(EntityTypeBuilder<PagamentoColaborador> builder)
    {
        builder.ToTable("pagamentos_colaboradores");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.ColaboradorId).HasColumnName("colaborador_id");
        builder.Property(p => p.VendaServicoId).HasColumnName("venda_servico_id");
        builder.Property(p => p.Valor).HasColumnName("valor");
        builder.Property(p => p.Status).HasColumnName("status");
        builder.Property(p => p.DataPagamento).HasColumnName("data_pagamento");
        builder.Property(p => p.CriadoEm).HasColumnName("criado_em");
        builder.Property(p => p.AtualizadoEm).HasColumnName("atualizado_em");
        builder.Property(p => p.CriadoPor).HasColumnName("criado_por");
        builder.Property(p => p.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
