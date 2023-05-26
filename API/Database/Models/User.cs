using Auth;
using Microsoft.AspNetCore.Identity;

namespace Database.Models
{
    public class User : IdentityUser<Guid>, IUser<Guid>
    {
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }

        public User()
        {
            Tests = new List<Test>();
            QuestionAnswers = new List<QuestionAnswer>();
        }
    }
}
