using BL.IdentityServer.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BL.IdentityServer.Controllers;

[ApiController]
[Route("[user]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    // TODO: Move to a different layer?
    //[HttpPost]
    //public async Task<IActionResult> Create(User user)
    //{
    //    ApplicationUser appUser = new()
    //    {
    //        UserName = user.Name,
    //        Email = user.Email
    //    };

    //    IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

    //    return result.Succeeded ? 
    //        Ok() 
    //        : throw new HttpResponseException(HttpStatusCode.InternalServerError); ;

    //    //else
    //    //{
    //    //    foreach (IdentityError error in result.Errors)
    //    //        ModelState.AddModelError("", error.Description);
    //    //}
    //}
}