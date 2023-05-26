using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Entity<TKey> : IEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public Entity(TKey id)
        {
            Id = id;
        }

        public Entity() : this(default!)
        {
        }
    }
}
