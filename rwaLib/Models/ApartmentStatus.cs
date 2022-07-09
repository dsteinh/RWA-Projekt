using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    public class ApartmentStatus
    {
        public int Id { get; set; }
        public string NameEng { get; set; }

        public override string ToString() => $"{NameEng}";
    }
}
