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
    public IActionResult Create(string name, string address, string ssn)
    {
        _studentService.Create(name, address, ssn);
        return Ok();
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get(Guid guid)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Authorize]
    public IActionResult Update(Guid guid,
        string name, string address, string ssn)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Authorize]
    public IActionResult Delete(Guid guid)
    {
        throw new NotImplementedException();
    }

}
