using System.ComponentModel.DataAnnotations;

namespace BL.IdentityServer.Domain.Users;

public class User
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
