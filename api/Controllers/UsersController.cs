using AutoMapper;
using Contracts;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public UsersController(ILoggerManager logger, IMapper mapper, IRepositoryManager repository)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var users = await _repository.User.GetAllUsersAsync(trackChanges: false);
            if (users == null)
            {
                _logger.LogInfo($"Users doesn't exist in the database.");
                return NotFound();
            }

            return Ok(users);
        }
    }
}
