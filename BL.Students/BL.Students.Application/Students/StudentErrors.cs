using BL.Students.Domain.Errors;

namespace BL.Students.Application.Students;

internal static class StudentErrors
{
    internal static Error InvalidSSN = new("Student.SSN", "Ivalid Social Security Number");
}
