using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Data.Entities;

public class BoilerplateEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string BoilerplateType { get; set; } = null!; // E.g. "Privacy Policy", "Terms & Conditions"
    public string BoilerplateContent { get; set; } = null!; // The actual content of the boilerplate text

    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
