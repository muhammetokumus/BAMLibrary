using BAM.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category Get(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Category GetByCategoryName(string name);
    }
}
