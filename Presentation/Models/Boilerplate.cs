namespace Presentation.Models;

public class Boilerplate
{
    public string Id { get; set; } = null!;
    public string? BoilerplateType { get; set; }  
    public string? BoilerplateContent { get; set; } 
    public DateTime? CreatedAt { get; set; }
}
