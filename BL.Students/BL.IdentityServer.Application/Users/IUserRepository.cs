using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace BL.IdentityServer.Application.Users;

public interface IUserRepository
{
    Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
    Task<ApplicationUser> FindByEmailAsync(string email);
    Task<SignInResult> LoginAsync(ApplicationUser user, string password);
}
