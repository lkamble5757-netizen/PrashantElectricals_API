using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PrashantApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DefaultController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new { Message = "You are authenticated!" });
}
