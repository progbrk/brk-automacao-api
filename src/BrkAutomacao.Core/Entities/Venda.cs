namespace BrkAutomacao.Core.Entities;

public class Venda
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid ProdutoId { get; set; }
    public Guid? ParceiroId { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; } = "orcamento";
    public DateOnly DataVenda { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
