using BL.Students.Api.Errors;
using BL.Students.Application.Abstractions;
using BL.Students.Application.Students;
using BL.Students.Domain.Students;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BL.Students.Api.Students;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("students", async (
            StudentService studentService,
            string name, 
            string address, 
            string ssn,
            CancellationToken cancel) =>
        {
            Result<StudentId> result = await studentService.CreateAsync(name, address, ssn, cancel);
            return result.IsSuccess ? TypedResults.Ok(result.Value) : result.ToProblemDetails();
        });
    }
}
