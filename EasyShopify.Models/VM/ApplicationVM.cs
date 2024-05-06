using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.Models
{
    public class ApplicationVM
    {
        public IEnumerable<ApplicationUser> UserList { get; set; }
    }
}
