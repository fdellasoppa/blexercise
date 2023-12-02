using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace BL.IdentityServer.Application.Users;

public interface IUserService
{
    Task<CreateUserResult> CreateAsync(User user);
    Task<SignInResult?> LoginAsync(string email, string password);
}
