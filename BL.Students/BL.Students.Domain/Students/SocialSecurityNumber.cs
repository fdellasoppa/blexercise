namespace BL.Students.Domain.Students;

public record SocialSecurityNumber
{
    private const int NumbersLength = 9;
    private const int DefaultLength = 11;

    private SocialSecurityNumber(string value) => Value = value;

    public string Value { get; init; }

    public static SocialSecurityNumber? Create(string value)
    {
        if (string.IsNullOrEmpty(value)) 
            return null;

        if (value.Length == NumbersLength)
            return new SocialSecurityNumber(value.Insert(3, "-").Insert(5,"-"));

        return value.Length != DefaultLength ?
            null
            : new SocialSecurityNumber(value);
    }
}
