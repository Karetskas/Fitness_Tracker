namespace Fitness_tracker.Domain.AbstractClass
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Deleted { get; set; }
    }
}
