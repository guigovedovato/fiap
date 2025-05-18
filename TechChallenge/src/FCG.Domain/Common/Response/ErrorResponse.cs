namespace FCG.Domain.Common.Response;

public record ErrorResponse
{
    public required string ErrorId { get; set; }
    public int StatusCode { get; set; }
    public required string Message { get; set; }

}
