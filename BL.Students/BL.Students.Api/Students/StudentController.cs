using BL.Students.Domain.Students;
using BL.Students.Application.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BL.Students.Api.Students;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly IStudentService _studentService;

    public StudentController(
        ILogger<StudentController> logger,
        IStudentService userService)
    {
        _logger = logger;
        _studentService = userService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync(string name, string address, string ssn,
        CancellationToken cancel)
    {
        await _studentService.CreateAsync(name, address, ssn, cancel);
        return Ok();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAsync(Guid guid,
        CancellationToken cancel)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateAsync(Guid guid,
        string name, string address, string ssn,
        CancellationToken cancel)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteAsync(Guid guid, 
        CancellationToken cancel)
    {
        throw new NotImplementedException();
    }

}
