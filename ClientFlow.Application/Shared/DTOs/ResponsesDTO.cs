namespace ClientFlow.Application.Shared.DTOs;

public class CreationResponseDTO
{
    public Guid Id { get; set; }
    public string Message { get; set; }
}

public class ErrorResponseDTO
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
}
