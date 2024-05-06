using EasyShopify.Data;
using EasyShopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.DataAccess.Repository.OrderHeader_Repository
{
    internal class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderHeaderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Update(OrderHeader orderHeader)
        {
            dbContext.Update(orderHeader);
        }
    }
}
