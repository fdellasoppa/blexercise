using BL.Students.Application.Abstractions;
//using Microsoft.AspNetCore.Mvc;

namespace BL.Students.Api.Errors;

public static class ResultExtensions
{
    public static IResult ToProblemDetails<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("Can't convert success result to problem");
        }

        return Results.Problem(
            statusCode: StatusCodes.Status400BadRequest,
            title: "Bad Request",
            type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            extensions: new Dictionary<string, object?>
            {
                { "errors", new[] { result.Error } }
            }
            );
    }

    // TODO: Remove
    //public static IActionResult ActionToProblemDetails<T>(this Result<T> result)
    //{
    //    if (result.IsSuccess)
    //    {
    //        throw new InvalidOperationException("Can't convert success result to problem");
    //    }

    //    return (IActionResult) Results.Problem(
    //        statusCode: StatusCodes.Status400BadRequest,
    //        title: "Bad Request",
    //        type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"
    //        );
    //}
}
