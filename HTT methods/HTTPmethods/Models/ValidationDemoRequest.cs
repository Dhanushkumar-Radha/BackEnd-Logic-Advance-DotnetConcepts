using System.ComponentModel.DataAnnotations;

namespace httpmethods.models;
public class ValidationDemoRequest
{
    [Required]
    [StringLength(100,MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 characters")]
    public string? Title {get; set;}
    [Range(1, 10, ErrorMessage = "Priority must be between 1 and 10")]
    public int Priority {get; set;}
    
    [Required(ErrorMessage = "OwnerEmail is required.")]
    [EmailAddress(ErrorMessage = "OwnerEmail must be a valid email address.")]
    public string? OwnerEmail { get; set; }
}
