using BL.Students.Api.Errors;
using BL.Students.Application.Abstractions;
using BL.Students.Application.Students;
using BL.Students.Domain.Students;

namespace BL.Students.Api.Students;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("mstudent", async (
            IStudentService studentService,
            string name, 
            string address, 
            string ssn,
            CancellationToken cancel) =>
        {
            Result<StudentId> result = await studentService.CreateAsync(name, address, ssn, cancel);
            return result.IsSuccess ? TypedResults.Ok(result.Value) : result.ToProblemDetails();
        });

        app.MapGet("students", async (
            IStudentService studentService,
            CancellationToken cancel) =>
        {
            Result<List<Student>> result = await studentService.GetAllAsync(cancel);
            return result.IsSuccess ? TypedResults.Ok(result.Value) : result.ToProblemDetails();
        });
    }
}
