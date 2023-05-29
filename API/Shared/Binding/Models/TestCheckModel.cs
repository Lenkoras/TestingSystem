using System.ComponentModel.DataAnnotations;

namespace Shared.Binding.Models
{
    public class TestCheckModel : ModelEntity
    {
        [Required]
        public TestQuestionCheckModel[] Questions { get; set; }

        public TestCheckModel()
        {
            Questions = Array.Empty<TestQuestionCheckModel>();
        }
    }
}
