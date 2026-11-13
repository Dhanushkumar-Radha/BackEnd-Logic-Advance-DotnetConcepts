/*4.Routing (attribute routing, route constraints)

1. Routing flow 

request -> useRouting() { url + http method + constraits match check } -> useAuthorization() -> controll action -> model binding

 Conventional routing vs Attribute routing

 Conventional routing means URL structure-ah centralized-ah Program.cs-la define pannuvom.
 Attribute routing means URL-ah directly controller or action mela attributes use panni define pannuvom.

*/

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/route-demo")]
public class RoutingDemoController : ControllerBase
{
    [HttpGet("guid/{id:int}")]
    public IActionResult Getbyguid(int id)
    {
        return Ok(new { type ="guid" , id});
    }
    
    // GET /api/v1/routing-demo/codes/{code}   (exactly 3 chars)
    [HttpGet("codes/{code:length(3)}")]
    public IActionResult GetCode(string code)
        => Ok(new { type = "code", code });

    // GET /api/v1/routing-demo/priority/{level}   (1 to 5 mattum)
    [HttpGet("priority/{level:int:range(1,5)}")]
    public IActionResult GetPriority(int level)
        => Ok(new { type = "priority", level });

    // GET /api/v1/routing-demo/orders/{id}   (id 1 or above)
    [HttpGet("orders/{id:int:min(1)}")]
    public IActionResult GetOrder(int id)
        => Ok(new { type = "order", id });

    // GET /api/v1/routing-demo/files/a/b/c   (slashes-ah kooda capture)
    [HttpGet("files/{*path}")]
    public IActionResult GetFile(string path)
        => Ok(new { type = "file", path });

    // GET /api/v1/routing-demo/named/5   (route name use pannum)
    [HttpGet("named/{id:int}", Name = "GetNamedItem")]
    public IActionResult GetNamed(int id)
        => Ok(new { type = "named", id, routeName = "GetNamedItem" });

    // GET /api/v1/ping   (absolute route — controller prefix ignore aagum)
    [HttpGet("/api/v1/ping")]
    public IActionResult Ping() => Ok("pong");
}