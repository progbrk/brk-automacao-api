namespace BrkAutomacao.Core.Entities;

public class Colaborador
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Cargo { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public bool Ativo { get; set; } = true;
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
