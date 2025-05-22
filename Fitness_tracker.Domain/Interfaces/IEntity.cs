namespace Fitness_tracker.Domain.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Deleted { get; set; }
    }
}
