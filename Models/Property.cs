using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pisofinderapi.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Title { get; set; }

        [StringLength(1000)]
        public required string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int SquareFeet { get; set; }

        [DataType(DataType.Date)]
        public DateTime ListedDate { get; set; }

        // Foreign Key for PropertyType
        [ForeignKey("PropertyType")]
        public int PropertyTypeId { get; set; }
        public required PropertyType PropertyType { get; set; }

        // Foreign Key for Agent
        [ForeignKey("Agent")]
        public int AgentId { get; set; }
        public required Agent Agent { get; set; }

        // Navigation Property for Address (One-to-One)
        public required Address Address { get; set; }

        // Navigation Property for Images (One-to-Many)
        public ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();
    }
}

