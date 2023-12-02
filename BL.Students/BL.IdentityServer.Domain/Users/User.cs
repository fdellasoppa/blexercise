using System.ComponentModel.DataAnnotations;

namespace BL.IdentityServer.Domain.Users;

public class User
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email")]
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Password { get; set; } = string.Empty;

    public bool HasValidName()
    {
        return Name.All(char.IsLetterOrDigit);
    }

    public bool HasValidPassword()
    {
        return Password.Length > 7
            && ContainsUpper(Password)
            && ContainsNumeric(Password)
            && ContainsAlphanumeric(Password);
    }

    private static bool ContainsAlphanumeric(string password)
    {
        return !password.All(char.IsLetterOrDigit);
    }

    private static bool ContainsNumeric(string password)
    {
        return password.Any(char.IsDigit);
    }

    private static bool ContainsUpper(string password)
    {
        return password.Any(char.IsUpper);
    }
}
