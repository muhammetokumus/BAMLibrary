using BAM.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM.Entities.Concrete
{
    public class Category : Base
    {
        public List<Book> Books { get; set; }
    }
}
