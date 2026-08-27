namespace BrkAutomacao.Core.Entities;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Papel { get; set; } = "fundador";
    public bool Ativo { get; set; } = true;
    public string? SenhaHash { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
}
