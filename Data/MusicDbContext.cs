using Microsoft.EntityFrameworkCore;
using music_api.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace music_api.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Music> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>()
                .ToTable("Tracks")
                .HasKey(m => m.Id);

            modelBuilder.Entity<Music>()
                .Property(m => m.Id)
                .HasColumnName("TrackId");
        }
    }
}
