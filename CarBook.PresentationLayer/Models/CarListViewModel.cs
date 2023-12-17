using CarBook.EntityLayer.Concrete;

namespace CarBook.PresentationLayer.Models
{
    public class CarListViewModel
    {
        public List<Car> Cars { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
