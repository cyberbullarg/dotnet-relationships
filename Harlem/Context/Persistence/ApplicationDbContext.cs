using APIService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIService.Context.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Relationship between character and backpack
            builder.Entity<Character>()
                   .HasOne(c => c.Backpack)
                   .WithOne(b => b.Character)
                   .HasForeignKey<Backpack>(b => b.CharacterId);

            // Relationship between character and weapon
            builder.Entity<Character>()
                   .HasMany(c => c.Weapons)
                   .WithOne(w => w.Character)
                   .HasForeignKey(w => w.CharacterId);
        }
    }
}
