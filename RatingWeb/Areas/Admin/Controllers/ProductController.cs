// ProductController.cs

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RatingWeb.Models;
using RatingWeb.Models.ViewModel;
using RatingWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RatingWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            // Populate ViewBag.Categories for the dropdown
            ViewBag.Categories = _unitOfWork.Category.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                Category selectedCategory = _unitOfWork.Category.Get(c => c.Id == product.CategoryId);

                if (selectedCategory == null)
                {
                    TempData["error"] = "Invalid category selected.";
                    return RedirectToAction("Create");
                }

                product.Category = selectedCategory;
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();

                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _unitOfWork.Category.GetAll();
            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product product = _unitOfWork.Product.Get(u => u.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _unitOfWork.Category.GetAll();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _unitOfWork.Category.GetAll();
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product product = _unitOfWork.Product.Get(u => u.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            try
            {
                Product product = _unitOfWork.Product.Get(u => u.Id == id);
                if (product == null)
                {
                    return NotFound();
                }

                _unitOfWork.Product.Remove(product);
                _unitOfWork.Save();
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"An error occurred: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Rate(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            RatingViewModel ratingViewModel = new RatingViewModel
            {
                ProductId = productFromDb.Id
            };

            return View(ratingViewModel);
        }

        [HttpPost]
        public IActionResult Rate(RatingViewModel ratingViewModel)
        {
            if (ModelState.IsValid)
            {
                Rating rating = new Rating
                {
                    ProductId = ratingViewModel.ProductId,
                    Stars = ratingViewModel.Rating
                };

                _unitOfWork.Rating.Add(rating);
                _unitOfWork.Save();
                TempData["success"] = "Rating added successfully";
                return RedirectToAction("Index");
            }

            return View(ratingViewModel);
        }
    }
}
