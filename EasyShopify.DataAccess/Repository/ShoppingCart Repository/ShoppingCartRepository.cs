using EasyShopify.Data;
using EasyShopify.Migrations;
using EasyShopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.DataAccess.Repository.ShoppingCart_Repository
{
    public class ShoppingCartRepository : Repository<ShppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ShoppingCartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Update(ShppingCart shoppingCart)
        {
            dbContext.Update(shoppingCart);   
        }
    }
}
