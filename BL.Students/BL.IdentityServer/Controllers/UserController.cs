using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BL.IdentityServer.Controllers;

[ApiController]
[Route("[user]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(
        ILogger<UserController> logger,
        UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        ApplicationUser appUser = new()
        {
            UserName = user.Name,
            Email = user.Email
        };
    
        // TODO: Move to a different layer?
        IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

        return result.Succeeded ?
            Ok()
            : StatusCode(StatusCodes.Status500InternalServerError); // TODO: Add more info?
    }
}