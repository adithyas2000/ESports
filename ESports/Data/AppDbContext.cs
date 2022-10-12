
﻿using ESports.Models;
using Microsoft.EntityFrameworkCore;

namespace ESports.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<TrophyRegistration> TrophyRegistrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrophyRegistration>()
                .HasKey(o => new { o.TrophyID,o.PlayerNIC });
        }
        public DbSet<Trophy> Trophies { get; set; }
    }
}

