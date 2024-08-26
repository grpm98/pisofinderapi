using System.ComponentModel.DataAnnotations;

namespace pisofinderapi.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public required string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public required string PhoneNumber { get; set; }

        // Navigation Property for Properties (One-to-Many)
        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
