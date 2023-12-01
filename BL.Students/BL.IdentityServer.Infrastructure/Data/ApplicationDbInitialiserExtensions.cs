using BL.IdentityServer.Domain.Roles;
using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BL.IdentityServer.Infrastructure.Data;

public static class ApplicationDbInitialiserExtensions
{

    public static IIdentityServerBuilder SeedData(this IIdentityServerBuilder builder)
    {
        return builder.SeedRoles().SeedInitialUsers();
    }

    public static IIdentityServerBuilder SeedRoles(this IIdentityServerBuilder builder)
    {
        // Default roles
        var provider = builder.Services.BuildServiceProvider();
        var roleManager = provider.GetService<RoleManager<ApplicationRole>>();

        if (roleManager is null)
        {
            return builder;
        }

        var administratorRole = new ApplicationRole()
        {
            Name = Roles.Administrator
        };

        var role = roleManager.FindByNameAsync(administratorRole.Name).Result;
        if (role is null)
        {
            var _ = roleManager.CreateAsync(administratorRole).Result;
        }

        return builder;
    }

    public static IIdentityServerBuilder SeedInitialUsers(this IIdentityServerBuilder builder)
    {
        var provider = builder.Services.BuildServiceProvider();
        var userManager = provider.GetService<UserManager<ApplicationUser>>();

        if (userManager is null)
            return builder;

        // Default user
        var administrator = new ApplicationUser 
        { 
            UserName = "administrator@localhost", 
            Email = "administrator@localhost" 
        };

        var user = userManager.FindByNameAsync(administrator.UserName).Result;
        if (user is null)
        {
            var _ = userManager.CreateAsync(administrator, "Passw0rd!").Result;
            var _2 = userManager.AddToRolesAsync(administrator, new[] { Roles.Administrator }).Result;
        }

        return builder;
    }
}
