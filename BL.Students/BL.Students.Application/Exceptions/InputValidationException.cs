
namespace BL.Students.Application.Exceptions;

public class InputValidationException : ApplicationException
{
    public InputValidationException(string? message) : base(message)
    {
    }
}
