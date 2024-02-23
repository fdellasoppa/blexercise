using Microsoft.AspNetCore.Mvc;

namespace BL.Students.Api.Errors;

    
[Route("/error")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{

    public IActionResult HandleError() =>
        Problem();
}
