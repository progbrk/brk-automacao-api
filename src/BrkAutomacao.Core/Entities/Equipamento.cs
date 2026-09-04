using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BrkAutomacao.Core.Entities;

public class Equipamento
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid? VendaId { get; set; }
    public string TipoDispositivo { get; set; } = "KC868-A16";
    public string? Identificador { get; set; }
    public string? IpVpn { get; set; }
    public string Status { get; set; } = "ativo";
    public DateOnly? DataInstalacao { get; set; }

    /// <summary>Tipo de conexão pro srv-brk-client importar ("HomeAssistant"/"Esp"/"Kc"). Nulo = ainda não configurado.</summary>
    public string? TipoConexao { get; set; }

    /// <summary>Token de acesso (ex: long-lived access token do Home Assistant), só relevante quando TipoConexao=HomeAssistant.
    /// Nunca é serializado — o próprio srv-brk-client é a única coisa que precisa dele, via endpoint dedicado restrito a chamadas de sistema.</summary>
    [JsonIgnore]
    public string? Token { get; set; }

    [NotMapped]
    public bool TemToken => Token != null;

    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
