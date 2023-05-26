using Auth;
using Database.Models;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services
{
    public class ApplicationAuthorizationService : IAuthorizationService<User>
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public ApplicationAuthorizationService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public async ValueTask<User?> AuthorizeAsync(string userName, string password)
        {
            return await repositoryWrapper.Users.FirstOrDefaultAsync(user => user.UserName == userName);
        }
    }
}
