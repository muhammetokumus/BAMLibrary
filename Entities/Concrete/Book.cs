using BAM.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM.Entities.Concrete
{
    public class Book : Base
    {
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        public int InStock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; } 
    }
}
