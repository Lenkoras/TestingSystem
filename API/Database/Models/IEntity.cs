using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public interface IEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
