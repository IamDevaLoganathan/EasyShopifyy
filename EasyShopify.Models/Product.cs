using System.ComponentModel.DataAnnotations;

namespace EasyShopify.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Product Title")]
        public string Ttile { get; set; }

        [Display(Name = "About Product")]
        public string Description { get; set; }

        [Display(Name = "Enter ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "Author's Name")]
        public string Author { get; set; }

        [Display(Name = "List Price")]
        public int ListPrice { get; set; }

        [Display(Name = "Price For 1-50")]
        public int Price { get; set; }

        [Display(Name = "Price For 50+")]
        public int Price50 { get; set; }

        [Display(Name = "Price For 100+")]
        public int Price100 { get; set; }

        [Display(Name ="Upload Product Image")]
        public string ImgURL { get; set; }


    }
}
