using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int TotalRooms { get; set; }
        public double Price { get; set; }
        public ApartmentOwner Owner { get; set; }
        public string Status { get; set; }
        public int BeachDistance { get; set; }

    }
}
