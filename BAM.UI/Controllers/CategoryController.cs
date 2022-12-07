using BAM.Business.Abstract;
using BAM.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAM.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.Get(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }
    }
}
