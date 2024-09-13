using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entitites;


namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-STM2NG9;initial Catalog=MultiShopDiscountDb;integrated security=true");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
