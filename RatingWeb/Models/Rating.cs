using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RatingWeb.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Stars { get; set; }

        // You can add additional properties like UserId if you want to track who gave the rating

        // Navigation property for the related product
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
