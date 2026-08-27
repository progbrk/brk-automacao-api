namespace BrkAutomacao.Core.Entities;

public class Parceiro
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Tipo { get; set; } = "instalacao_hidraulica";
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public decimal PercentualComissao { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
