using BAM.Entities.Concrete;

namespace BAM.UI.Models
{
    public class AddBookViewModel
    {
        public Book book { get; set; }
        public List<Category> categories { get; set; }
    }
}
