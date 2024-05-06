using EasyShopify.Migrations;
using EasyShopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.DataAccess.Repository.ShoppingCart_Repository
{
    public interface IShoppingCartRepository : IRepository<ShppingCart>
    {
        void Update(ShppingCart shoppingCart);
    }
}
