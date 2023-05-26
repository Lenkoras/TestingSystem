namespace Database.Models
{
    public class Test : Entity
    {
        /// <summary>
        /// A short text description of the test.
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<TestQuestion> TestQuestions { get; set; }

        public Test()
        {
            Description = string.Empty;
            Users = new List<User>();
            TestQuestions = new List<TestQuestion>();
        }

    }
}
