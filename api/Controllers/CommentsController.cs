using AutoMapper;
using Api.ActionFilters;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CommentsController(ILoggerManager logger, IMapper mapper, IRepositoryManager repository)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments([FromQuery] CommentParameters commentParameters)
        {

            var comments = await _repository.Comment.GetCommentsAsync(commentParameters, trackChanges: false);
            if (comments == null)
            {
                _logger.LogInfo($"Comments doesn't exist in the database.");
                return NotFound();
            }

            return Ok(comments);
        }

        [HttpGet("{id}", Name = "GetCommentForUser")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _repository.Comment.GetCommentWithRepliesAsync(id, trackChanges: false);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentForUser([BindRequired] Guid userId, [FromBody] CommentForCreationDto comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _repository.User.GetUserAsync(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {userId} doesn't exist in the database.");
                return NotFound();
            }

            var commentEntity = _mapper.Map<Comment>(comment);

            _repository.Comment.CreateCommentForUser(userId, commentEntity);
            await _repository.SaveAsync();

            var commentToReturn = _mapper.Map<CommentDto>(commentEntity);

            return CreatedAtRoute("GetCommentForUser", new { userId, id = commentToReturn.UserId }, commentToReturn);

        }

        [HttpPost("{id}/reply")]
        public async Task<IActionResult> CreateReplyForComment(int id, [BindRequired] Guid userId, [FromBody] CommentsReplyForCreationDto comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _repository.User.GetUserAsync(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {userId} doesn't exist in the database.");
                return NotFound();
            }

            var existingcommentEntity = await _repository.Comment.GetCommentAsync(id, trackChanges: true);
            if (existingcommentEntity == null)
            {
                _logger.LogInfo($"Comment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var commentEntity = _mapper.Map<Comment>(comment);

            _repository.Comment.CreateCommentsReplyForUser(id, userId, commentEntity);
            await _repository.SaveAsync();

            var commentToReturn = _mapper.Map<CommentDto>(commentEntity);

            return CreatedAtRoute("GetCommentForUser", new { userId, id = commentToReturn.UserId }, commentToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateUserForCommentExistsAttribute))]
        public async Task<IActionResult> UpdateCommentForUser(int id, [BindRequired] Guid userId, [FromBody] CommentForUpdateDto comment)
        {
            var commentEntity = await _repository.Comment.GetCommentAsync(id, trackChanges: true);
            if (commentEntity == null)
            {
                _logger.LogInfo($"Comment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(comment, commentEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateUserForCommentExistsAttribute))]
        public async Task<IActionResult> DeleteCommentForUser(int id, [BindRequired] Guid userId)
        {
            var commentForUser = await _repository.Comment.GetCommentAsync(id, trackChanges: false);

            _repository.Comment.DeleteComment(commentForUser);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
