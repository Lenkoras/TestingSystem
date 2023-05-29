namespace Database.Models
{
    public class Test : Entity
    {
        /// <summary>
        /// Name of the test.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short text description of the test.
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<TestQuestion> TestQuestions { get; set; }

        public Test()
        {
            Name = string.Empty;
            Description = string.Empty;
            Users = new List<User>();
            TestQuestions = new List<TestQuestion>();
        }

    }
}
