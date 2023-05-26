using Database.Models;

namespace Database.Repositories
{
    public interface IRepositoryWrapper
    {
        IRepository<User> Users { get; }
        IRepository<Test> Tests { get; }
        IRepository<TestQuestion> TestQuestions { get; }
        IRepository<QuestionAnswer> QuestionAnswers { get; }

    }
}
