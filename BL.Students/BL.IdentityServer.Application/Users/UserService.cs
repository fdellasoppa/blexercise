using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace BL.IdentityServer.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IdentityResult> CreateAsync(User user)
    {
        ApplicationUser appUser = new()
        {
            UserName = user.Name,
            Email = user.Email
        };

        return _userRepository.CreateAsync(appUser, user.Password);
    }

    public async Task<SignInResult?> LoginAsync(string email, string password)
    {
        ApplicationUser appUser = await _userRepository.FindByEmailAsync(email);
        if (appUser != null)
        {
            return await _userRepository.LoginAsync(appUser, password);
        }
        return null;
    }
}
