using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICommentRepository
    {
        Task<PagedList<Comment>> GetCommentsAsync(CommentParameters commentParameters, bool trackChanges);
        Task<Comment> GetCommentAsync(int commentId, bool trackChanges);
        void CreateCommentForUser(Guid userId, Comment comment);
        void DeleteComment(Comment comment);
    }
}
