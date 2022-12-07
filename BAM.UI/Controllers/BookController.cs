using BAM.Business.Abstract;
using BAM.Entities.Concrete;
using BAM.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAM.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        IBookService _bookService;
        ICategoryService _categoryService;

        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var books = _bookService.GetAll();
            return View(books);
        }

        public IActionResult Add(AddBookViewModel p)
        {
            p = new();
            p.categories = _categoryService.GetAll();
            return View(p);
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel p,string category)
        {
            p.book.Status = true;
            p.categories = _categoryService.GetAll();
            var addedCategory = _categoryService.GetByCategoryName(category);
            p.book.CategoryId = addedCategory.Id;
            _bookService.Add(p.book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(AddBookViewModel p,int id)
        {
            p = new();
            p.categories = _categoryService.GetAll();
            p.book = _bookService.Get(id);
            var category = _categoryService.Get(p.book.CategoryId);
            ViewBag.Selected = category.Name;
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(AddBookViewModel p)
        {
            var category = _categoryService.GetByCategoryName(p.book.Category.Name);
            p.book.CategoryId = category.Id;
            p.book.Status = true;
            _bookService.Update(p.book);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            var book = _bookService.Get(id);
            if (book.Status)
            {
                book.Status = false;
            }
            else
            {
                book.Status = true;
            }
            _bookService.Update(book);
            return RedirectToAction("Index");
        }
    }
}
