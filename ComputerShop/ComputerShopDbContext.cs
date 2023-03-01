using ComputerShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop
{
    public class ComputerShopDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbConnection = "Server=localhost;Database=ComputerShop;Uid='root';Pwd=Kavi1998.;";
            MySqlServerVersion mySqlServerVersion = new MySqlServerVersion(new Version(8, 0, 30));
            optionsBuilder.UseMySql(dbConnection, mySqlServerVersion);
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Cart_Item> cart_items { get; set; }
        public DbSet<Cart_order> cart_Orders { get; set; }
        public DbSet<Tracking> trackings { get; set; }

    }
}
