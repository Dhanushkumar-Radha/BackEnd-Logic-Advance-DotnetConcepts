namespace HTTPmethods.Models;
public class TaskPatchRequest
{
    public string? Title { get; set; }
    public bool? IsCompleted { get; set; }
}