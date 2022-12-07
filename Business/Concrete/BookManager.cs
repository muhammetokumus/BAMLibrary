using BAM.Business.Abstract;
using BAM.Core.DataAccess;
using BAM.DataAccess.Abstract;
using BAM.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM.Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void Add(Book book)
        {
            _bookDal.Add(book);
        }

        public void Delete(Book book)
        {
            _bookDal.Delete(book);
        }

        public Book Get(int id)
        {
            return _bookDal.Get(x => x.Id == id);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public List<Book> GetByCategory(int CategoryId)
        {
            return _bookDal.GetAll(x => x.CategoryId == CategoryId);
        }


        public List<Book> GetByDescription(string description)
        {
            return _bookDal.GetAll(d => d.Description.Contains(description));
        }

        public void Update(Book book)
        {
            _bookDal.Update(book);
        }
    }
}
