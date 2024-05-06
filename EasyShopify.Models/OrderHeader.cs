using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.Models
{
    public class OrderHeader
    {
      
        public int OrderHeaderId { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        
        public int OrderTotal { get; set; }

        public DateTime OrderDate { get; set; } 
        public DateTime ShippingDate { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

    }
}
