using Microsoft.AspNetCore.Identity;

namespace BL.IdentityServer.Application.Users;

public class CreateUserResult
{
    public bool DoesUserExist { get; set; }
    public bool IsPasswordValid { get; set; }
    public IdentityResult? IdentityResult { get; set; }
}
