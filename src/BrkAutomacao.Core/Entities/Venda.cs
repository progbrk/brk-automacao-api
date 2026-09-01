namespace BrkAutomacao.Core.Entities;

public class Venda
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid? ParceiroId { get; set; }
    public string? Descricao { get; set; }

    /// <summary>Desconto em R$ abatido do total (coluna real, informada pelo usuário).</summary>
    public decimal Desconto { get; set; }

    /// <summary>Calculado pelo repositório (soma de VendaItens + VendaServicos, menos Desconto) — não é uma coluna do banco.</summary>
    public decimal Valor { get; set; }

    public string Status { get; set; } = "orcamento";
    public DateOnly DataVenda { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
