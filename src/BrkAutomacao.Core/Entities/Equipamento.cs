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
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
