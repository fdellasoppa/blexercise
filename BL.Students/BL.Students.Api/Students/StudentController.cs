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
    public async Task<IActionResult> GetAsync(string guid,
        CancellationToken cancel)
    {
        await _studentService.GetAsync(guid, cancel);
        return Ok();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateAsync(string guid,
        string name, string address, string ssn,
        CancellationToken cancel)
    {
        await _studentService.UpdateAsync(guid, name, address, ssn, cancel);
        return Ok();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteAsync(string guid,
    CancellationToken cancel)
    {
        await _studentService.DeleteAsync(guid, cancel);
        return Ok();
    }

}
