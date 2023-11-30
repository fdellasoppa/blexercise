using BL.IdentityServer.Application.Users;
using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BL.IdentityServer.Controllers;

[ApiController]
[Route("[user]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(
        ILogger<UserController> logger,
        IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        // TODO: Move mapping to repository???
        //User appUser = new()
        //{
        //    Name = user.Name,
        //    Email = user.Email
        //};
    
        // TODO: Move to a different layer?
        //IdentityResult result = await _userService.CreateAsync(appUser, user.Password);
        IdentityResult result = await _userService.CreateAsync(user);

        return result.Succeeded ?
            Ok()
            : StatusCode(StatusCodes.Status500InternalServerError); // TODO: Add more info?
    }
}