using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("produtos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Nome).HasColumnName("nome");
        builder.Property(p => p.Descricao).HasColumnName("descricao");
        builder.Property(p => p.Tipo).HasColumnName("tipo");
        builder.Property(p => p.PrecoVenda).HasColumnName("preco_venda");
        builder.Property(p => p.CustoBase).HasColumnName("custo_base");
        builder.Property(p => p.Ativo).HasColumnName("ativo");
        builder.Property(p => p.FotoUrl).HasColumnName("foto_url");
        builder.Property(p => p.CriadoEm).HasColumnName("criado_em").ValueGeneratedOnAdd();
        builder.Property(p => p.AtualizadoEm).HasColumnName("atualizado_em").ValueGeneratedOnAddOrUpdate();
        builder.Property(p => p.CriadoPor).HasColumnName("criado_por");
        builder.Property(p => p.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
