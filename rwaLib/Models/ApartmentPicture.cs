using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    
    public class ApartmentPicture
    {
        public int Id { get; set; }
        public string Base64Content { get; set; }
        public string Name { get; set; }
        public bool IsRepresentative { get; set; }

        public override string ToString() => $"{Name}";
    }
}
