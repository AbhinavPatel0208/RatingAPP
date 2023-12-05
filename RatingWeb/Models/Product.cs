using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RatingWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Product Image URL")]
        public string ImageUrl { get; set; }

        [Required]
        [DisplayName("Product Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000")]
        public decimal Price { get; set; }

        [Range(1, 5, ErrorMessage = "Product Rating must be between 1 and 5")]
        public int Rating { get; set; }
    }
}
