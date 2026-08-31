namespace BrkAutomacao.Core.Entities;

public class PagamentoColaborador
{
    public Guid Id { get; set; }
    public Guid ColaboradorId { get; set; }
    public Guid VendaServicoId { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; } = "pendente";
    public DateOnly? DataPagamento { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
