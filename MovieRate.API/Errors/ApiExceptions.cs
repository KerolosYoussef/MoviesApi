using Microsoft.AspNetCore.Identity;

namespace MovieRate.API.Errors;

public class ApiExceptions : ApiResponse
{
    public ApiExceptions(int statusCode, IList<IdentityError>? errors = null, string? message = null, string? details = null) : base(statusCode, errors, message)
    {
        Details = details;
    }

    public string? Details { get; set; }
}