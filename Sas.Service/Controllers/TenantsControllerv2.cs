using Microsoft.AspNetCore.Mvc;

namespace Sas.Service.Controllers.v2;

[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2.0")]

public class TenantsController : ControllerBase
{

    [MapToApiVersion("2.0")]
    [HttpGet("version")]
    public virtual IActionResult GetVersion()
    {
        return Ok("Response from version 2.0");
    }
}