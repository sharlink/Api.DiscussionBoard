using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateUser(User user) => Create(user);


        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) =>
           await FindAll(trackChanges)
            .OrderBy(c => c.FirstName)
            .ToListAsync();

        public async Task<User> GetUserAsync(Guid userId, bool trackChanges) =>
           await FindByCondition(c => c.UserId.Equals(userId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
           await FindByCondition(x => ids.Contains(x.UserId), trackChanges)
            .ToListAsync();

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public async Task<User> UserAuthenticateAsync(string userName, string password, bool trackChanges) =>
             await FindByCondition(c => c.UserName.Equals(userName), trackChanges)
            .SingleOrDefaultAsync();

    }
}
