using Fitness_tracker.Domain.Interfaces;

namespace Fitness_tracker.Domain.Entities
{
    public sealed class User : IEntity
    {
        public Guid Id { get; set; }
        
        public DateTime Created { get; set; }

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? AvatarUrl { get; set; }

        public DateTime? Deleted { get; set; }
    }
}
