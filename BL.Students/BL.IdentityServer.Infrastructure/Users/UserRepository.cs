using BL.IdentityServer.Application.Users;
using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BL.IdentityServer.Infrastructure.Users;

public class UserRepository : UserManager<ApplicationUser>, IUserRepository
{
    public UserRepository(
        IUserStore<ApplicationUser> store, 
        IOptions<IdentityOptions> optionsAccessor, 
        IPasswordHasher<ApplicationUser> passwordHasher, 
        IEnumerable<IUserValidator<ApplicationUser>> userValidators, 
        IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, 
        ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
        IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) 
        : base(store, 
            optionsAccessor, 
            passwordHasher, 
            userValidators, 
            passwordValidators, 
            keyNormalizer, 
            errors, 
            services, 
            logger)
    {
    }

    public Task<IdentityResult> CreateAsync(User user)
    {
        ApplicationUser appUser = new()
        {
            UserName = user.Name,
            Email = user.Email
        };

        return CreateAsync(appUser, user.Password);
    }
}
