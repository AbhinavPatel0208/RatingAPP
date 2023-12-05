using Microsoft.AspNetCore.Mvc;

using RatingWeb.Models;
using RatingWeb.Repository.IRepository;

namespace RatingWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfwork =unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfwork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _unitOfwork.Category.Add(obj);
                _unitOfwork.Category.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfwork.Category.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();3
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfwork.Category.Update(obj);
                _unitOfwork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfwork.Category.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfwork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfwork.Category.Remove(obj);
            _unitOfwork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
