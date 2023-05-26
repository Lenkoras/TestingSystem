namespace Shared.Models
{
    public class TestQuestionShort : Entity
    {
        /// <summary>
        /// The text description of the test question.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// All answers to this question.
        /// </summary>
        public ICollection<QuestionAnswerShort> Answers { get; set; }

        public TestQuestionShort()
        {
            Text = string.Empty;
            Answers = Array.Empty<QuestionAnswerShort>();
        }
    }
}
