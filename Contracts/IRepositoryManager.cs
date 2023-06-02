using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        ICommentRepository Comment { get; }
        Task SaveAsync();
    }
}
