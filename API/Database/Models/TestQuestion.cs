namespace Database.Models
{
    public class TestQuestion : Entity
    {
        /// <summary>
        /// The text description of the test question.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// All answers to this question.
        /// </summary>
        public virtual ICollection<QuestionAnswer>? Answers { get; set; }

        public TestQuestion()
        {
            Text = string.Empty;
        }
    }
}
