using KASHOP.Models.Categoy;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.Data
{
    public class ApplicationDBContext  : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<CategoryTranslation> categoriesTranslations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KAShop12;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            


        }
    }
}
