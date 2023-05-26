namespace Database.Models
{
    public abstract class Entity : Entity<Guid>
    {
        public Entity(Guid id)
        {
            Id = id;
        }

        public Entity() : this(Guid.NewGuid())
        {
        }
    }
}
