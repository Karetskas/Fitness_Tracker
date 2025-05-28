using Fitness_tracker.Domain.Entities;
using Fitness_tracker.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Fitness_tracker.Infrastructure.Contexts
{
    public sealed class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
