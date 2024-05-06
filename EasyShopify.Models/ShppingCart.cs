using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.Models
{
    public class ShppingCart
    {

        public int ShppingCartId { get; set; }

        [Range(1,1000, ErrorMessage ="Count should not exceed 200")]
        public int Count { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

       /* public int OrderPrice { get; set; }*/
        [NotMapped]
        public int Price { get; set; }

      






    }
}
