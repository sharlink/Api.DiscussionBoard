using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryCommentExtensions
    {
        public static IQueryable<Comment> FilterComments(this IQueryable<Comment> comments, string userName) =>
            comments.Where(e => (e.Content.Contains(userName)));

        public static IQueryable<Comment> Search(this IQueryable<Comment> comments, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return comments;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return comments.Where(e => e.Content.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Comment> Sort(this IQueryable<Comment> comments, string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))            
                return comments.OrderBy(e => e.ReplyingTo);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Comment>(orderByQueryString);           

            if (string.IsNullOrWhiteSpace(orderQuery))
                return comments.OrderBy(e => e.ReplyingTo);

            return comments.OrderBy(orderQuery);
        }
    }
}
