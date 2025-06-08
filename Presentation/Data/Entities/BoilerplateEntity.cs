using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Data.Entities;

public class BoilerplateEntity
{
    [Key]
    string Id { get; set; } = Guid.NewGuid().ToString();

    string BoilerplateType { get; set; } = null!; // E.g. "Privacy Policy", "Terms & Conditions"
    string BoilerplateContent { get; set; } = null!; // The actual content of the boilerplate text

    [Column(TypeName = "datetime2")]
    DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
