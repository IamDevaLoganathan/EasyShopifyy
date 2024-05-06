using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

       /* public string PostalCode { get; set; }*/

    }
}
