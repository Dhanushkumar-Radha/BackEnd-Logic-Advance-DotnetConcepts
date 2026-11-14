// 5.Model binding ([FromRoute], [FromQuery], [FromBody], [FromHeader])

/*
Http Request -> 
|
Routing -> route values extract aagum 
|
 Model binding -> route/query/body/header -> parameters
 |
 validation -> DataAnnotations rules
 |
 [Apicontroller] -> check <- Models invalid ->automatic 400
 |
 controller action

  1.Binding sources summary

  [FromRoute] -> URL Path Segment
  [FromQuery] -> query string
  [FromBody] -> Request body (json)
  [FromHeader] -> http header
  [FromForm] -> form data
*/
namespace HTTPmethods.Controllers;
public enum Workstatus
{
    open,
    Inprogress,
    Done
}
public class TaskQuery
{
    public Workstatus? Workstatus {get; set;}
    public bool? IsComleted {get; set;}
    public int Page {get; set;}
    public int PageSize {get; set;}
}

public class BindingDemoBody
{
    public string? Title {get; set;}
    public Workstatus Status {get; set;}
}
