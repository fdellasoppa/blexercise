using Microsoft.AspNetCore.Identity;

namespace BL.IdentityServer.Application.Users;

public class CreateUserResult
{
    public bool DoesUserExist { get; set; }
    public bool IsPasswordOrNameInvalid { get; set; }
    public IdentityResult? IdentityResult { get; set; }
}
