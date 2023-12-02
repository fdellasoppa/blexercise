using BL.IdentityServer.Application.Users;
using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BL.IdentityServer.Controllers;

[ApiController]
[Route("[controller]")]
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
    [Authorize]
    public async Task<IActionResult> Create(User user)
    {
        // TODO: User name only digits and chars
        var result = await _userService.CreateAsync(user);

        return result.DoesUserExist ?
            Conflict()
            : result.IsPasswordOrNameInvalid ?
                BadRequest() :
                    result.IdentityResult != null
                    && result.IdentityResult.Succeeded ?
                        Ok()
                        : StatusCode(StatusCodes.Status500InternalServerError); // TODO: Add more info?
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var result = await _userService.LoginAsync(email, password);

        return result != null 
            && result.Succeeded ?
                Ok()
                : Unauthorized();
    }

}