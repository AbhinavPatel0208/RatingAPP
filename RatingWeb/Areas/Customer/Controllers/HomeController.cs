using Microsoft.AspNetCore.Mvc;
using RatingWeb.Models;
using RatingWeb.Models.ViewModels;
using RatingWeb.Repository.IRepository;
using System.Diagnostics;
using System.Linq;

namespace RatingWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int? categoryId, string sortOrder)
        {
            IEnumerable<Product> objProductList;

            if (categoryId.HasValue)
            {
                objProductList = _unitOfWork.Product.GetAll(p => p.CategoryId == categoryId.Value);
            }
            else
            {
                objProductList = _unitOfWork.Product.GetAll();
            }

            // Sorting logic
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price" ? "price_desc" : "price";
            ViewBag.StarsSortParam = sortOrder == "stars" ? "stars_desc" : "stars";

            switch (sortOrder)
            {
                case "name_desc":
                    objProductList = objProductList.OrderByDescending(p => p.Name);
                    break;
                case "price":
                    objProductList = objProductList.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    objProductList = objProductList.OrderByDescending(p => p.Price);
                    break;
                case "stars":
                    objProductList = objProductList.OrderByDescending(p => p.Rating);
                    break;
                case "stars_desc":
                    objProductList = objProductList.OrderBy(p => p.Rating);
                    break;
                default:
                    objProductList = objProductList.OrderBy(p => p.Name);
                    break;
            }

            // Populate ViewBag.Categories with your category data
            ViewBag.Categories = _unitOfWork.Category.GetAll(); // Adjust this based on your actual data retrieval logic

            // Replace the following lines with your logic to populate the view model
            var viewModel = new ProductViewModel
            {
                Products = objProductList.ToList(),
                CategoryId = categoryId,
                SortOrder = sortOrder
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult UpdateRating(int productId, int newRating)
        {
            // Retrieve the product from the database
            var product = _unitOfWork.Product.Get(p => p.Id == productId);

            if (product != null)
            {
                // Update the product's rating based on the new rating
                // You may want to consider a weighted average or other logic
                product.Rating = newRating;

                _unitOfWork.Save();

              
                return RedirectToAction("Index");
            }

            
            return NotFound();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
