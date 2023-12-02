using BL.IdentityServer.Application.Users;
using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace BL.IdentityServer.Infrastructure.Users;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserRepository(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
    {
        return _userManager.CreateAsync(user, password);
    }

    public Task<ApplicationUser> FindByEmailAsync(string email)
    {
        return _userManager.FindByEmailAsync(email);
    }

    public Task<SignInResult> LoginAsync(ApplicationUser user, string password)
    {
        return _signInManager.PasswordSignInAsync(user, password, false, false);
    }
}
