using Database.Models;

namespace Database.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext context;

        private IRepository<User>? users;
        private IRepository<Test>? tests;
        private IRepository<TestQuestion>? testQuestions;
        private IRepository<QuestionAnswer>? questionAnswers;

        public IRepository<User> Users => users ?? (users = BuildRepository<User>());
        public IRepository<Test> Tests => tests ?? (tests = BuildRepository<Test>());
        public IRepository<TestQuestion> TestQuestions => testQuestions ?? (testQuestions = BuildRepository<TestQuestion>());
        public IRepository<QuestionAnswer> QuestionAnswers => questionAnswers ?? (questionAnswers = BuildRepository<QuestionAnswer>());

        public RepositoryWrapper(ApplicationDbContext context)
        {
            this.context = context;
        }

        private IRepository<TEntity> BuildRepository<TEntity>() where TEntity : class =>
            new Repository<TEntity>(context);
    }
}
