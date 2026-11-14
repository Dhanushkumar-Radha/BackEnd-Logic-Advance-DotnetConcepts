using httpmethods.models;
using Microsoft.AspNetCore.Mvc;

namespace HTTPmethods.Controllers;
[ApiController]
[Route("api/v1/validation-demo")]
public class ValidationDemoController : ControllerBase
{
    [HttpGet("auto")]
    public IActionResult createAuto([FromBody] ValidationDemoRequest request)
    {
        return Ok(new { source = "auto", request });
    }
    
}