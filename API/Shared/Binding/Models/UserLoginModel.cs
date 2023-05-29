using System.ComponentModel.DataAnnotations;

namespace Shared.Binding.Models
{
    public class UserLoginModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;
    }
}
