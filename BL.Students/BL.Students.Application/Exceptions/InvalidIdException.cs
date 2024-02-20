namespace BL.Students.Application.Exceptions;

public class InvalidIdException : Exception
{
    public InvalidIdException() : base("Id is not valid")
    {
    }
}
