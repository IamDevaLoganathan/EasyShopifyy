using EasyShopify.Data;
using EasyShopify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.DataAccess.Repository.ApplicationUser_Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ApplicationUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Update(ApplicationUser applicationUser)
        {
            dbContext.Update(applicationUser);
        }
    }
}
