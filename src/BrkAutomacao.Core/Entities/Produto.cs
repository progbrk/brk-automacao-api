namespace BrkAutomacao.Core.Entities;

public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public string Tipo { get; set; } = null!;
    public decimal? PrecoVenda { get; set; }
    public decimal? CustoBase { get; set; }
    public bool Ativo { get; set; } = true;
    public string? FotoUrl { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
