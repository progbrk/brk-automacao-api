namespace BrkAutomacao.Core.Entities;

public class VendaItem
{
    public Guid Id { get; set; }
    public Guid VendaId { get; set; }
    public Guid ProdutoId { get; set; }
    public decimal Quantidade { get; set; } = 1;
    public decimal PrecoUnitario { get; set; }

    /// <summary>Calculado pelo banco (quantidade * preco_unitario) — só-leitura.</summary>
    public decimal? ValorTotal { get; private set; }

    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
