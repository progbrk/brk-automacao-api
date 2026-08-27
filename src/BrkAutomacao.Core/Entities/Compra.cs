namespace BrkAutomacao.Core.Entities;

public class Compra
{
    public Guid Id { get; set; }
    public Guid FornecedorId { get; set; }
    public Guid? VendaId { get; set; }
    public string Item { get; set; } = null!;
    public decimal Quantidade { get; set; } = 1;
    public decimal ValorUnitario { get; set; }
    public decimal Frete { get; set; }
    public decimal Imposto { get; set; }

    /// <summary>Calculado pelo banco (quantidade * valor_unitario) — só-leitura.</summary>
    public decimal? ValorTotal { get; private set; }

    /// <summary>Calculado pelo banco (valor_total + frete + imposto) — só-leitura.</summary>
    public decimal? ValorTotalComEncargos { get; private set; }

    public DateOnly DataCompra { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
