using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    [Serializable]
    public class User
    {


        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public override string ToString() => $"{Username}";
    }
}
