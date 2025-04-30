using Microsoft.EntityFrameworkCore;
using InventoryManagementApi.Models;



namespace InventoryManagementApi.Data
{
    public class DataContext : DbContext
    {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
                
        }
    }
}
