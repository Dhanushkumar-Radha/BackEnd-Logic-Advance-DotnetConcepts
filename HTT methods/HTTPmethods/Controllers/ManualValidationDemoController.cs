using httpmethods.models;
using Microsoft.AspNetCore.Mvc;

namespace HTTPmethods.Controllers;
public class ManualValidationDemoController : ControllerBase
{
    [HttpPost("manual")]
    public IActionResult createManual([FromBody] ValidationDemoRequest request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(new { source = "manual", request });
    }
}