using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ActionFilters
{
    public class ValidateCommentExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;

        public ValidateCommentExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var traceChanges = context.HttpContext.Request.Method.Equals("PUT");
            var id = (int)context.ActionArguments["CommentId"];
            var comment = await _repository.Comment.GetCommentAsync(id, traceChanges);

            if(comment == null)
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
