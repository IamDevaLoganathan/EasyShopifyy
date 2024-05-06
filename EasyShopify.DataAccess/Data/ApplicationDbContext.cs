using EasyShopify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyShopify.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
    }
}
