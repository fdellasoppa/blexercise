using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace BL.IdentityServer.Application.Users;

public interface IUserRepository
{
    Task<IdentityResult> CreateAsync(User user);
}
