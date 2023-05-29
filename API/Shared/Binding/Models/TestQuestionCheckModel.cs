using System.ComponentModel.DataAnnotations;

namespace Shared.Binding.Models
{
    public class TestQuestionCheckModel : ModelEntity
    {
        [Required]
        public string AnswerId { get; set; }

        public TestQuestionCheckModel()
        {
            AnswerId = string.Empty;
        }
    }
}
