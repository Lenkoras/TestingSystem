namespace Database.Models
{
    public class QuestionAnswer : Entity
    {
        /// <summary>
        /// The question answer text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Determines whether the answer is correct.
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        /// A parent test question of this answer.
        /// </summary>
        public virtual TestQuestion? Parent { get; set; }

        /// <summary>
        /// Collection of users who selected this answer.
        /// </summary>
        public virtual ICollection<User> Users { get; set; }

        public QuestionAnswer()
        {
            Text = string.Empty;
            Users = new List<User>();
        }
    }
}
