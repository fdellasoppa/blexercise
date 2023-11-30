using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace BL.IdentityServer.Application.Users;

public interface IUserService
{
    Task<IdentityResult> CreateAsync(User user);
}
