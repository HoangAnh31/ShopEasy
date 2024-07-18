using Microsoft.EntityFrameworkCore;


namespace ShopEasy.Models
{
    public class ShopEasyContext : DbContext
    {
        public ShopEasyContext(DbContextOptions<ShopEasyContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
