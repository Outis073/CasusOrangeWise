using CasusOrangeWise.Models;
using Microsoft.EntityFrameworkCore;

namespace CasusOrangeWise.Data
{
    public class ShoppingContext : DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<ShoppingSunday> shoppingSundays { get; set; }
        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {

        }
    }
}
