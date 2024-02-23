namespace BL.Students.Application.Exceptions;

public class InvalidIdException : InputValidationException
{
    public InvalidIdException() : base("Id is not valid")
    {
    }
}
