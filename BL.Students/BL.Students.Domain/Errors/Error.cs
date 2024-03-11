namespace BL.Students.Domain.Errors;

public sealed record Error(string Code, string? Description = null)
{
    public static Error None => new (string.Empty);

    //public static implicit operator Result(Error error) 
    //    => Result.Failure(error);
}
