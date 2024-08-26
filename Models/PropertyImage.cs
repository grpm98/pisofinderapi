using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using pisofinderapi.Models;

namespace pisofinderapi.Models
{
    public class PropertyImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public required string ImageUrl { get; set; }

        [StringLength(500)]
        public required string Description { get; set; }

        // Foreign Key for Property
        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property? Property { get; set; }
    }
}