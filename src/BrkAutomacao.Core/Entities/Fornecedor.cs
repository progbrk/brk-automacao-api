namespace BrkAutomacao.Core.Entities;

public class Fornecedor
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Contato { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
