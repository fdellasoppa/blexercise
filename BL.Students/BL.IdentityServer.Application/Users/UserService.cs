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

    public async Task<CreateUserResult> CreateAsync(User user)
    {
        var appUser = await _userRepository.FindByEmailAsync(user.Email);

        if (appUser != null)
        {
            return new CreateUserResult()
            {
                DoesUserExist = true,
            };
        }

        if (!user.HasValidPassword() || !user.HasValidName())
        {
            return new CreateUserResult()
            {
                IsPasswordOrNameInvalid = true,
            };
        }

        appUser = new()
        {
            UserName = user.Name,
            Email = user.Email
        };

        return new CreateUserResult()
        {
            IdentityResult = await _userRepository.CreateAsync(appUser, user.Password)
        };
    }

    public async Task<SignInResult?> LoginAsync(string email, string password)
    {
        var appUser = await _userRepository.FindByEmailAsync(email);
        if (appUser != null)
        {
            return await _userRepository.LoginAsync(appUser, password);
        }
        return null;
    }
}
