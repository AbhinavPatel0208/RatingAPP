// ProductViewModel.cs
using System.Collections.Generic;
using RatingWeb.Models;

namespace RatingWeb.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int? CategoryId { get; set; }
        public string SortOrder { get; set; }
    }
}
