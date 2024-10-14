using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Sas.UserService.Errors;
namespace Sas.UserService.Controllers;


public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public ActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem();
    }
}