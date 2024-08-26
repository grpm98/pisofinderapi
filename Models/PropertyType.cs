using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pisofinderapi.Models;
public class PropertyType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    // Navigation Property for Properties (One-to-Many)
    public ICollection<Property> Properties { get; set; } = new List<Property>();
}
