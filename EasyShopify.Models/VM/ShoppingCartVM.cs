using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.Models
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShppingCart> ListCart { get; set; }

        public Product Product { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
