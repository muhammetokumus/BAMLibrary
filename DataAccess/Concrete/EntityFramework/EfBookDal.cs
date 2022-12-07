using BAM.Core.DataAccess.EntityFramework;
using BAM.DataAccess.Abstract;
using BAM.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAM.DataAccess.Concrete.EntityFramework
{


    public class EfBookDal : EfEntityRepositoryBase<Book, BAMLibraryContext>, IBookDal
    {
    }
}
