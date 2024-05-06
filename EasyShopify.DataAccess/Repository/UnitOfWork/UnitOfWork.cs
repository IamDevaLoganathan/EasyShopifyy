using EasyShopify.Data;
using EasyShopify.DataAccess.Repository.ApplicationUser_Repository;
using EasyShopify.DataAccess.Repository.OrderDetail_Repository;
using EasyShopify.DataAccess.Repository.OrderHeader_Repository;
using EasyShopify.DataAccess.Repository.Product_Repository;
using EasyShopify.DataAccess.Repository.ShoppingCart_Repository;
using EasyShopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.DataAccess.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        public IProductRepository Product {  get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IShoppingCartRepository ShppingCart { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            Product = new ProductRepository(dbContext);
            ShppingCart = new ShoppingCartRepository(dbContext);
            ApplicationUser = new ApplicationUserRepository(dbContext);
            OrderDetail = new OrderDetailRepository(dbContext);
            OrderHeader = new OrderHeaderRepository(dbContext);
        
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
