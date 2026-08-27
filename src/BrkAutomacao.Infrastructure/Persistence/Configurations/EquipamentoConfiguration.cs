using BrkAutomacao.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrkAutomacao.Infrastructure.Persistence.Configurations;

public class EquipamentoConfiguration : IEntityTypeConfiguration<Equipamento>
{
    public void Configure(EntityTypeBuilder<Equipamento> builder)
    {
        builder.ToTable("equipamentos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.ClienteId).HasColumnName("cliente_id");
        builder.Property(e => e.VendaId).HasColumnName("venda_id");
        builder.Property(e => e.TipoDispositivo).HasColumnName("tipo_dispositivo");
        builder.Property(e => e.Identificador).HasColumnName("identificador");
        // inet no Postgres — Npgsql só mapeia nativamente pra IPAddress, não string;
        // conversor mantém a propriedade como string (mais simples pra API JSON).
        builder.Property(e => e.IpVpn)
            .HasColumnName("ip_vpn")
            .HasColumnType("inet")
            .HasConversion(
                v => v == null ? null : System.Net.IPAddress.Parse(v),
                v => v == null ? null : v.ToString());
        builder.Property(e => e.Status).HasColumnName("status");
        builder.Property(e => e.DataInstalacao).HasColumnName("data_instalacao");
        builder.Property(e => e.CriadoEm).HasColumnName("criado_em").ValueGeneratedOnAdd();
        builder.Property(e => e.AtualizadoEm).HasColumnName("atualizado_em").ValueGeneratedOnAddOrUpdate();
        builder.Property(e => e.CriadoPor).HasColumnName("criado_por");
        builder.Property(e => e.AtualizadoPor).HasColumnName("atualizado_por");
    }
}
