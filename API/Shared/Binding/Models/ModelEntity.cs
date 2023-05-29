using System.ComponentModel.DataAnnotations;

namespace Shared.Binding.Models
{
    public abstract class ModelEntity
    {
        [Required]
        public string Id { get; set; }

        public ModelEntity()
        {
            Id = string.Empty;
        }
    }
}
