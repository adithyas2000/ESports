
﻿using ESports.Models;
using Microsoft.EntityFrameworkCore;

namespace ESports.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<TrophyRegistration> TrophyRegistrations { get; set; }
        public DbSet<Trophy> Trophies { get; set; }
    }
}

