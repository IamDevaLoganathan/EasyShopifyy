using EasyShopify.DataAccess.Repository.ApplicationUser_Repository;
using EasyShopify.DataAccess.Repository.OrderDetail_Repository;
using EasyShopify.DataAccess.Repository.OrderHeader_Repository;
using EasyShopify.DataAccess.Repository.Product_Repository;
using EasyShopify.DataAccess.Repository.ShoppingCart_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.DataAccess.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IShoppingCartRepository ShppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderHeaderRepository OrderHeader { get; }


        void Save();
    }
}
