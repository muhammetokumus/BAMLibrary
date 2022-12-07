using BAM.Business.Abstract;
using BAM.DataAccess.Abstract;
using BAM.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
             _categoryDal= categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category Get(int id)
        {
           return _categoryDal.Get(x=>x.Id==id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByCategoryName(string name)
        {
            return _categoryDal.Get(x => x.Name == name);
        }
    }
}
