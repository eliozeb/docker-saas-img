using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sas.Database.Entities;

namespace Sas.UserService.Controllers;

[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAsync()
    {
        var users = new List<User>()
        {
            new User() {Id = 111, FirstName="Roger", LastName="Waters", Email = "rw@pf.com"},
            new User() {Id = 222, FirstName = "Dave", LastName = "Gilmore", Email = "dg@pf.com"},
            new User() {Id = 333, FirstName = "Nick", LastName = "Mason", Email = "nm@pf.com"}
        };

        return Ok(await Task.FromResult(users));
    }
}