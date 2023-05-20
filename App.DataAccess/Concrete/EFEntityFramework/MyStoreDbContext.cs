using App.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Concrete.EFEntityFramework
{
    public partial class MyStoreDbContext : DbContext
    {
        public MyStoreDbContext()
        {

        }

        public MyStoreDbContext(DbContextOptions<MyStoreDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        public DbSet<Product> Products { get; set; } = null!;
    }
}   
