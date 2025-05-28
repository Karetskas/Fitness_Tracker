using Fitness_tracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitness_tracker.Infrastructure.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasAlternateKey(u => u.Email);
            builder.HasAlternateKey(u => u.Username);
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.Email).IsRequired();
        }
    }
}
