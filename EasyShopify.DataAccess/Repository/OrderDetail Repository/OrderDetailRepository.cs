using EasyShopify.Data;
using EasyShopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.DataAccess.Repository.OrderDetail_Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Update(OrderDetail orderDetail)
        {
            dbContext.Update(orderDetail);
        }
    }
}
