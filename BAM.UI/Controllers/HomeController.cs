using BAM.Business.Abstract;
using BAM.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BAM.UI.Controllers
{
    public class HomeController : Controller
    {

        ICategoryService _categoryService;
        IBookService _bookService;

        public HomeController(ICategoryService categoryService, IBookService bookService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel()
            {
                Books = _bookService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string description)
        {
            BooksViewModel booksViewModel = new();
            booksViewModel.Books = _bookService.GetByDescription(description);
            booksViewModel.Categories = _categoryService.GetAll();
            return View("Books", booksViewModel);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = _bookService.Get(id);
            if (id == null || _bookService.Get(id) == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View(book);
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Books()
        {
            var model = new BooksViewModel()
            {
                Categories = _categoryService.GetAll(),
                Books = _bookService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Books(int id)
        {
            var model = new BooksViewModel()
            {
                Categories = _categoryService.GetAll(),
                Books = _bookService.GetByCategory(id)
            };
            var category = _categoryService.Get(id);
            ViewBag.CategoryName = category.Name;
            return View(model);
        }
    }
}