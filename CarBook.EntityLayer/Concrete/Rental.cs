using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.EntityLayer.Concrete
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public string? Message { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
