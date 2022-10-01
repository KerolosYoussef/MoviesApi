using Microsoft.AspNetCore.Identity;

namespace MovieRate.API.Errors;

public class ApiResponse
{
    public ApiResponse(int statusCode, IList<IdentityError> errors = null, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        Errors = errors;
    }

    public int StatusCode { get; }
    public string Message { get; }
    public IList<IdentityError> Errors { get; }

    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad Request.",
            401 => "Unauthorized.",
            404 => "Not found.",
            500 => "Server error.",
            _ => "Something went wrong, Please contact the support."
        };
    }
}