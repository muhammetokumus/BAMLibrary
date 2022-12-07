using BAM.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM.Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        List<Book> GetByDescription(string description);
        List<Book> GetByCategory(int CategoryId);
        Book Get(int id);
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}
