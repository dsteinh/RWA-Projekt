using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    public class ApartmentOwner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"{Name}";
    }
}
