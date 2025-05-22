using Fitness_tracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fitness_tracker.Infrastructure.Contexts
{
    public sealed class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext()
        {
        }

        public UserContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("User");
                user.HasAlternateKey(u => u.Email);
                user.HasAlternateKey(u => u.Username);
                user.Property(u => u.Username).IsRequired();
                user.Property(u => u.PasswordHash).IsRequired();
                user.Property(u => u.Email).IsRequired();
            });
        }
    }
}
