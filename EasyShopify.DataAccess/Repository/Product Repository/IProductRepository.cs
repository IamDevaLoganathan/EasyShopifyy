using EasyShopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.DataAccess.Repository.Product_Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
