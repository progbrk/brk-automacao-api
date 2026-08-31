namespace BrkAutomacao.Core.Entities;

public class Assinatura
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid? VendaId { get; set; }
    public Guid PlanoId { get; set; }
    public decimal ValorMensal { get; set; }
    public short DiaCobranca { get; set; }
    public string Status { get; set; } = "ativa";
    public DateOnly DataInicio { get; set; }
    public DateOnly? DataFim { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset AtualizadoEm { get; set; }
    public Guid CriadoPor { get; set; }
    public Guid AtualizadoPor { get; set; }
}
