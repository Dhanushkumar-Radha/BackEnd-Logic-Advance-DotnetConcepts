/*2.REST conventions and resource naming

1.REST - architectural Principle 
-Reprenstation State transfer

prinicple
1.Resource - > Eg:task,project
2.Uniform interface 
3.stateless
4.Representation

*/
using Microsoft.AspNetCore.Mvc;

namespace HTTPmethods.Controllers;

[ApiController]
[Route("api/v1/[controller]/{projectId:id}")]
public class ProjectTasksController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTaskforProject(int projectId)
    {
        return Ok(new { projectId, message = "Tasks for this project" });
    }
     // GET /api/v1/projects/tasks/5/3
    [HttpGet("{taskId:int}")]
    public IActionResult GetTaskInProject(int projectId, int taskId)
        => Ok(new { projectId, taskId });
}
