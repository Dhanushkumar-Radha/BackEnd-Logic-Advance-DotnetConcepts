using HTTPmethods.Models;
using Microsoft.AspNetCore.Mvc;
namespace HTTPmethods.Controllers;
[ApiController]
[Route("api/v1/tasks")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem>  _tasks = new()
    {
        new() { Id = 1, Title = "Task 1", IsComplete = false },
        new TaskItem { Id = 2, Title = "Task 2", IsComplete = true },
        new TaskItem { Id = 3, Title = "Task 3", IsComplete = false }
    };
    private static int _nextId = 2;
    [HttpGet]
    public IActionResult GetAllTasks()
    {
        return Ok(_tasks);
    }

       // GET /api/v1/tasks/1

    [HttpGet("{id:int}")]
    public IActionResult GetTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }


    [HttpPost]
    public IActionResult createTask([FromBody] TaskItem taskItem)
    {
        if (taskItem == null || string.IsNullOrWhiteSpace(taskItem.Title))
        {
            return BadRequest("Task title is required.");
        }

        taskItem.Id = _nextId++;
        _tasks.Add(taskItem);
        return CreatedAtAction(nameof(GetTask), new { id = taskItem.Id }, taskItem);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateTask(int id, [FromBody] TaskItem updatedTask)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
        if (existingTask == null)
        {
            return NotFound();
        }

        if (updatedTask == null || string.IsNullOrWhiteSpace(updatedTask.Title))
        {
            return BadRequest("Task title is required.");
        }

        existingTask.Title = updatedTask.Title;
        existingTask.IsComplete = updatedTask.IsComplete;

        return Ok(existingTask);
    }

    [HttpPatch("{id:int}")]

    public IActionResult PatchTask(int id, [FromBody] TaskPatchRequest patchRequest)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
        if (existingTask == null)
        {
            return NotFound();
        }

        if (patchRequest == null)
        {
            return BadRequest("Invalid request body.");
        }

        if (!string.IsNullOrWhiteSpace(patchRequest.Title))
        {
            existingTask.Title = patchRequest.Title;
        }

        if (patchRequest.IsCompleted.HasValue)
        {
            existingTask.IsComplete = patchRequest.IsCompleted.Value;
        }

        return Ok(existingTask);
    }


    [HttpDelete("{id:int}")]
    public IActionResult DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        _tasks.Remove(task);
        return NoContent();
    }
}