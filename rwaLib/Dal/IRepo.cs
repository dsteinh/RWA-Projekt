using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Dal
{
    public interface IRepo
    {
        IList<User> LoadUsers();
        
    }
}
