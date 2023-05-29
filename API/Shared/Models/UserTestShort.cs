namespace Shared.Models
{
    public class UserTestShort : Entity
    {
        /// <summary>
        /// A short text description of the test.
        /// </summary>
        public string Description { get; set; }

        public UserTestShort()
        {
            Description = string.Empty;
        }
    }
}
