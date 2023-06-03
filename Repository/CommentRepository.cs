using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public async Task<Comment> GetCommentAsync(int commentId, bool trackChanges) =>
           await FindByCondition(e => e.Id.Equals(commentId), trackChanges)
            .SingleOrDefaultAsync();


        public async Task<PagedList<Comment>> GetCommentsAsync(CommentParameters commentParameters, bool trackChanges)
        {
            var comments = await FindAll(trackChanges)
                .ToListAsync();

            return PagedList<Comment>
                 .ToPagedList(comments, commentParameters.PageNumber, commentParameters.PageSize);
        }


        public void CreateCommentForUser(Guid userId, Comment comment)
        {
            comment.UserId = userId;
            Create(comment);
        }

        public void DeleteComment(Comment comment)
        {
            Delete(comment);
        }

    }
}
