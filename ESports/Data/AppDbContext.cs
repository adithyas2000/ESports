using Microsoft.EntityFrameworkCore;
using ESports.Models;

namespace ESports.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<Trophy> Trophies { get; set; }
    }
}
