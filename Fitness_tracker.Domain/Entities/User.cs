using Fitness_tracker.Domain.AbstractClass;

namespace Fitness_tracker.Domain.Entities
{
    public sealed class User : Entity
    {
        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? AvatarUrl { get; set; }
    }
}
