using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<User> UserAuthenticateAsync(string userName, string password, bool trackChanges);
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
        Task<User> GetUserAsync(Guid userId, bool trackChanges);
        void CreateUser(User user);
        Task<IEnumerable<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteUser(User user);
    }
}
