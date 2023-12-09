using Microsoft.EntityFrameworkCore;
namespace Contact.Models
{
    public class ContactDBcontext : DbContext
    {
        public ContactDBcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<register> Contact { get; set; }
    }
}
