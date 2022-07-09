using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string NameEng { get; set; }
        public TagType Type { get; set; }
        public int ApartmentsUsing { get; set; }

        public override string ToString() => $"{NameEng}";
    }
}
