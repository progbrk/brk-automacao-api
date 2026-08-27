namespace BrkAutomacao.Core.Responses;

public class ResponseBase<T>
{
    public bool Success { get; set; } = true;
    public string? Message { get; set; }
    public T? Data { get; set; }
}
