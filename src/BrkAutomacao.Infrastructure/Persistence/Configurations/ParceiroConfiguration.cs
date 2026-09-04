using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class ParceiroConfiguration : IEntityTypeConfiguration<Parceiro>
{
    public void Configure(EntityTypeBuilder<Parceiro> builder)
    {
        builder.ToTable("parceiros");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Nome).HasColumnName("nome");
        builder.Property(p => p.Tipo).HasColumnName("tipo");
        builder.Property(p => p.Telefone).HasColumnName("telefone");
        builder.Property(p => p.Email).HasColumnName("email");
        builder.Property(p => p.PercentualComissao).HasColumnName("percentual_comissao");
        builder.Property(p => p.CriadoEm).HasColumnName("criado_em");
        builder.Property(p => p.AtualizadoEm).HasColumnName("atualizado_em");
        builder.Property(p => p.CriadoPor).HasColumnName("criado_por");
        builder.Property(p => p.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
