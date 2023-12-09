
using Microsoft.EntityFrameworkCore;

namespace Market.Models
{
    public class MarketDBcontext : DbContext
    {
        public MarketDBcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MarketComputer> Computermarket { get; set; }
    }

}
