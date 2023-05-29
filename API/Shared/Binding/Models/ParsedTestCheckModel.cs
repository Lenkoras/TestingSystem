namespace Shared.Binding.Models
{
    public class ParsedTestCheckModel : ParsedModelEntity
    {
        public ParsedTestQuestionCheckModel[] Questions { get; set; }

        public ParsedTestCheckModel()
        {
            Questions = Array.Empty<ParsedTestQuestionCheckModel>();
        }
    }
}
