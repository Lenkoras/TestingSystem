namespace Database.Models
{
    public class Entity : Entity<Guid>
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
