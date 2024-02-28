using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SharedKernel.Core;
public static class ResultExtension
{
    public static IResult ConvertToProblemDetails<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException();
        }

        if (result.Errors != null && result.Errors.Any())
        {
            return Results.Problem(new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Extensions = new Dictionary<string, object?>
                {
                    {"errors", result.Errors}
                }
            });
        }
        return Results.Problem(new ProblemDetails
        {
            Detail = result.Error.Message,
            Status = GetTitleAndStatusCode(result.Error).status,
            Title = GetTitleAndStatusCode(result.Error).title,
            Type = result.Error.ErrorType.ToString()
        });
    }

    private static (int status, string title) GetTitleAndStatusCode(Error error)
    {
        var statusCode = error.ErrorType switch
        {
            ErrorType.Failure => (StatusCodes.Status400BadRequest, error.ErrorCode),
            ErrorType.Validation => (StatusCodes.Status400BadRequest, error.ErrorCode),
            ErrorType.NotFound => (StatusCodes.Status404NotFound, error.ErrorCode),
            ErrorType.Unexpected => (StatusCodes.Status500InternalServerError, error.ErrorCode),
            ErrorType.Conflict => (StatusCodes.Status409Conflict, error.ErrorCode),
            ErrorType.Unauthorized => (StatusCodes.Status401Unauthorized, error.ErrorCode),
            ErrorType.Forbidden => (StatusCodes.Status403Forbidden, error.ErrorCode),
            ErrorType.None => (StatusCodes.Status400BadRequest, error.ErrorCode),
            ErrorType.Custom => (StatusCodes.Status400BadRequest, error.ErrorCode),
            _ => (StatusCodes.Status400BadRequest, error.ErrorCode)
        };

        return statusCode;
    }



}