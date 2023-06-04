using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public async Task<Comment> GetCommentAsync(int commentId, bool trackChanges) =>
            await FindByCondition(e => e.Id.Equals(commentId), trackChanges)
               .SingleOrDefaultAsync();        

        public async Task<List<CommentsWithRepliesDto>> GetCommentWithRepliesAsync(int commentId, bool trackChanges)
        {
            var comment = await FindByCondition(e => e.Id.Equals(commentId) | e.ParentCommantId.Equals(commentId), trackChanges)
             .ToListAsync();

            return MakeCommentsReplies(comment);
        }

        public async Task<PagedList<CommentsWithRepliesDto>> GetCommentsAsync(CommentParameters commentParameters, bool trackChanges)
        {
            var comments = await FindAll(trackChanges)
                .ToListAsync();

            var comtsWithReplies = MakeCommentsReplies(comments);

            return PagedList<CommentsWithRepliesDto>
                 .ToPagedList(comtsWithReplies, commentParameters.PageNumber, commentParameters.PageSize);
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

        private List<CommentsWithRepliesDto> MakeCommentsReplies(List<Comment> comments)
        {
            var parentComments = comments.Where(p => p.ParentCommantId == 0).ToList();
            var replyComments = comments.Where(p => p.ParentCommantId != 0).ToList();

            var comtsWithReplies = new List<CommentsWithRepliesDto>();

            if (parentComments.Any())
            {
                foreach (var comment in parentComments)
                {
                    var replies = replyComments.Where(r => r.ParentCommantId.Equals(comment.Id));
                    var _comments = new CommentsWithRepliesDto
                    {
                        commentId = comment.Id,
                        content = comment.Content,
                        createdAt = comment.CreatedAt,
                        score = comment.Score,
                        userId = comment.UserId,
                        replies = (from r in replies
                                   select new Reply
                                   {
                                       commentId = r.Id,
                                       content = r.Content,
                                       createdAt = r.CreatedAt,
                                       score = r.Score,
                                       replyingTo = r.ReplyingTo,
                                       userId = r.UserId,
                                   }).ToList()
                    };

                    comtsWithReplies.Add(_comments);
                }
            }

            return comtsWithReplies;
        }       
    }
}
