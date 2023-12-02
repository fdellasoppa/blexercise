namespace BL.Students.Domain.Students;

// TODO: I should probably move to this approach by Milan Jovanovic
// for User Passwords and Names in IdentityServer
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
        {
            if (value.All(char.IsDigit))
            {
                return new SocialSecurityNumber(value.Insert(5, "-").Insert(3, "-"));
            }

            return null;
        }

        if (value[3] != '-' || value[6] != '-')
            return null;

        var clean = value.Replace("-", string.Empty);
        if (clean.Length != NumbersLength)
            return null;

        if (!clean.All(char.IsDigit))
            return null;

        return value.Length != DefaultLength ?
            null
            : new SocialSecurityNumber(value);
    }
}
