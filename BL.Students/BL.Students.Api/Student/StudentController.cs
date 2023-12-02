using BL.Students.Application.Student;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BL.Students.Api.Student;

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
    public Task<IActionResult> Create(
        string name, string address, string ssn)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Authorize]
    public Task<IActionResult> Get(
        string name, string address, string ssn)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Authorize]
    public Task<IActionResult> Update(
        string name, string address, string ssn)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Authorize]
    public Task<IActionResult> Delete(
        string name, string address, string ssn)
    {
        throw new NotImplementedException();
    }

}
