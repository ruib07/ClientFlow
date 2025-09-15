using ClientFlow.Application.Shared.DTOs;

namespace ClientFlow.Application.Shared.Common;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T Data { get; }
    public ErrorResponseDTO Error { get; }
    public string Message { get; }

    private Result(bool isSuccess, T data, ErrorResponseDTO error, string message = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
        Message = message;
    }

    public static Result<T> Success(T data, string message = null) => new(true, data, null, message);
    public static Result<T> Fail(int statusCode, string message) => new(false, default, new ErrorResponseDTO
    {
        StatusCode = statusCode,
        Message = message
    });
}
