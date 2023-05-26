namespace Shared.Models
{
    public class QuestionAnswerShort : Entity
    {
        /// <summary>
        /// The question answer text.
        /// </summary>
        public string Text { get; set; }

        public QuestionAnswerShort()
        {
            Text = string.Empty;
        }
    }
}
