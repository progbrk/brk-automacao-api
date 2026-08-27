namespace BrkAutomacao.Core.Entities;

public class Comissao
{
    public Guid Id { get; set; }
    public Guid ParceiroId { get; set; }
    public Guid VendaId { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; } = "pendente";
    public DateOnly? DataPagamento { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
