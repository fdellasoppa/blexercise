using BL.IdentityServer.Application.Users;
using BL.IdentityServer.Domain.Users;
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
    public async Task<IActionResult> Create(User user)
    {
        // TODO: Add password rules validations
        // TODO: Fix start redirection to Swagger
        IdentityResult result = await _userService.CreateAsync(user);

        return result.Succeeded ?
            Ok()
            : StatusCode(StatusCodes.Status500InternalServerError); // TODO: Add more info?
    }
}