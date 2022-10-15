
﻿using ESports.Models;
using Microsoft.EntityFrameworkCore;

namespace ESports.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TrophyRegistration> TrophyRegistrations { get; set; }

        public DbSet<TrophyTeam> TrophyTeams { get; set; }

        public DbSet<PlayersBid> PlayersBids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrophyRegistration>()
                .HasKey(o => new { o.TrophyID, o.PlayerNIC });

            modelBuilder.Entity<TrophyTeam>()
                .HasKey(o => new { o.TrophyID, o.TeamId });

            modelBuilder.Entity<PlayersBid>()
                .HasKey(o => new { o.TrophyID, o.TeamId });
        }

        public DbSet<Trophy> Trophies { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}

