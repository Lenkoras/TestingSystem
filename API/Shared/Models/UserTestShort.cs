namespace Shared.Models
{
    public class UserTestShort : Entity
    {
        /// <summary>
        /// Name of the test.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short text description of the test.
        /// </summary>
        public string Description { get; set; }

        public UserTestShort()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
