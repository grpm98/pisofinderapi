using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pisofinderapi.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Street { get; set; }

        [Required]
        [StringLength(100)]
        public required string City { get; set; }

        [Required]
        [StringLength(100)]
        public required string State { get; set; }

        [Required]
        [StringLength(100)]
        public required string Country { get; set; }

        [Required]
        [StringLength(20)]
        public required string ZipCode { get; set; }

        // // Foreign Key for Property (One-to-One)
        // [ForeignKey("Property")]
        // public int PropertyId { get; set; }
        // public required Property Property { get; set; }
    }
}