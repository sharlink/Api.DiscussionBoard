using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ActionFilters
{
    public class ValidateUserForCommentExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ValidateUserForCommentExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true : false;

            var userId = (Guid)context.ActionArguments["userId"];
            var user = await _repository.User.GetUserAsync(userId, false);

            if(user == null)
            {
                _logger.LogInfo($"User with id: {userId} doesn't exist in the database.");
                context.Result = new NotFoundResult();
                return;
            }

            var id = (int)context.ActionArguments["id"];
            var comment = await _repository.Comment.GetCommentAsync(id, trackChanges);
            if (comment == null)
            {
                _logger.LogInfo($"Comment with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("comment", comment);
                await next();
            }
        }
    }
}
