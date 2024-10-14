using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; // Correct namespace for ExceptionFilterAttribute

namespace Sas.UserService.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            var exception = exceptionContext.Exception;
            var problemDetails = new ProblemDetails
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = "An exception occure while processing your request!",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message
            };

            exceptionContext.Result = new ObjectResult(problemDetails); // Add new keyword here

            exceptionContext.ExceptionHandled = true;
        }
    }
}
