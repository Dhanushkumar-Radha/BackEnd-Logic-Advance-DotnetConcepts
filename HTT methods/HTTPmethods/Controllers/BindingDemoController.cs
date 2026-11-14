using Microsoft.AspNetCore.Mvc;

namespace HTTPmethods.Controllers;
[ApiController]
[Route("api/v1/binding-demo")]
public class BindingDemoController : ControllerBase
{
    //[FromRoute]
    [HttpGet("tasks/{id:int}")]
    public IActionResult GetTask([FromRoute] int id)
    {
        return Ok(new {source ="Route",id});
    }

    // [FromQuery] simple -renamed Parameter + default value
    // GET /api/v1/binding-demo/search?q=learn&pageSize=10
    [HttpGet("search")]
    public IActionResult Search([FromQuery(Name ="q")] string? keyword, 
                                [FromQuery(Name = "pageSize")] int pageSize =20
                                )
    {
        return Ok(new { source ="Query", keyword,pageSize});
    }
     // [FromQuery] complex object
     // GET /api/v1/binding-demo/list?status=InProgress&isCompleted=false&page=2
    [HttpGet("list")]
    public IActionResult List([FromQuery] TaskQuery query)
    {
        return Ok(new {source = "query-object",query});
    }
     // [FromQuery] multiple values
    // GET /api/v1/binding-demo/tags?tag=api&tag=dotnet
    [HttpGet("tags")]
    public IActionResult Tags([FromQuery] List<string> tags)
    {
        return Ok(new { count= tags.Count});
    }
    [HttpPost("body")]
        // POST /api/v1/binding-demo/body
    public ActionResult Body([FromBody] BindingDemoBody body)
    {
        return Ok(new {source = "body",body});
    }
     // Inference: id route-la irukku, keyword query-la
    // GET /api/v1/binding-demo/inferred/5?keyword=test
    [HttpGet("inferred/{id:int}")]
    public IActionResult Inferred(int id,string? keyword)
    {
        return Ok(new {source = "inferred",id,keyword});
    }
      // Multiple sources in one action
    // PUT /api/v1/binding-demo/tasks/5?notify=true  + header + body
    [HttpPut("tasks/{id:int}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromQuery] bool notify,
        [FromHeader(Name = "X-Request-Source")] string? source,
        [FromBody] BindingDemoBody body)
        => Ok(new { id, notify, source, body });
}

