using BAM.Business.Abstract;
using BAM.UI.Models;
using BAM.UI.Models.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAM.UI.Controllers
{
    [Authorize(Roles = "Member")]
    public class BasketController : Controller
    {
        IBookService _bookService;

        public BasketController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var book = SessionHelpers.GetObjectFromJson<List<BookBasketViewModel>>(HttpContext.Session, "book");
            if (book == null)
                return View();

            ViewBag.Total = book.Sum(i => i.Book.Price * i.Quantity);

            return View(book);
        }

        public IActionResult Buy(int id)
        {
            if (SessionHelpers.GetObjectFromJson<List<BookBasketViewModel>>(HttpContext.Session, "book") == null)
            {
                var Book = new List<BookBasketViewModel>();
                Book.Add(new BookBasketViewModel
                {
                    Book = _bookService.Get(id),
                    Quantity = 1
                });
                SessionHelpers.SetObjectAsJson(HttpContext.Session, "book", Book);
            }
            else
            {
                var Book = SessionHelpers.GetObjectFromJson<List<BookBasketViewModel>>(HttpContext.Session, "book");
                int index = isExits(Book, id);
                if(index == -1)
                {
                    Book.Add(new BookBasketViewModel
                    {
                        Book = _bookService.Get(id),
                        Quantity = 1
                    });
                }
                else
                {
                    Book[index].Quantity++;
                }
                SessionHelpers.SetObjectAsJson(HttpContext.Session, "book", Book);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var Book = SessionHelpers.GetObjectFromJson<List<BookBasketViewModel>>(HttpContext.Session, "book");
            int index = isExits(Book, id);
            Book.RemoveAt(index);
            SessionHelpers.SetObjectAsJson(HttpContext.Session, "book", Book);
            return RedirectToAction("Index");
        }

        private int isExits(List<BookBasketViewModel> Book, int id)
        {
            for (int i = 0; i < Book.Count; i++)
            {
                if (Book[i].Book.Id.Equals(id))
                {
                    return i;
                    break;
                }
            }
            return -1;
        }
    }
}
