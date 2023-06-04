using Api.Controllers;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.DiscussionBoard.Test.Controllers
{
    public class CommentsControllerTests
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CommentsControllerTests()
        {
            _repository = A.Fake<IRepositoryManager>();
            _logger = A.Fake<ILoggerManager>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async void CommentsController_GetComments_ReturnOk()
        {
            //Arrange                     
            var commentParameters = A.Fake<CommentParameters>();
            var controller = new CommentsController(_logger, _mapper, _repository);

            //Act
            var result = await controller.GetComments(commentParameters);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void CommentsController_GetCommentsById_ReturnOk()
        {
            //Arrange  
            int id = 1;
            var controller = new CommentsController(_logger, _mapper, _repository);

            //Act
            var result = await controller.GetComment(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void CommentsController_CreateCommentForUser_ReturnOk()
        {
            //Arrange             
            Guid userId = Guid.NewGuid();
            var commentDto = A.Fake<CommentForCreationDto>();
            var comment = A.Fake<Comment>();
            A.CallTo(() => _mapper.Map<Comment>(commentDto));
            A.CallTo(() => _mapper.Map<CommentForCreationDto>(comment));
            var controller = new CommentsController(_logger, _mapper, _repository);

            //Act
            var result = await controller.CreateCommentForUser(userId, commentDto);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async void CommentsController_CreateReplyForComment_ReturnOk()
        {
            //Arrange
            int id = 1;
            Guid userId = Guid.NewGuid();
            var commentDto = A.Fake<CommentsReplyForCreationDto>();
            var comment = A.Fake<Comment>();
            A.CallTo(() => _mapper.Map<Comment>(commentDto));
            A.CallTo(() => _mapper.Map<CommentsReplyForCreationDto>(comment));
            var controller = new CommentsController(_logger, _mapper, _repository);

            //Act
            var result = await controller.CreateReplyForComment(id, userId, commentDto);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async void CommentsController_UpdateCommentForUser_ReturnOk()
        {
            //Arrange
            int id = 1;
            Guid userId = Guid.NewGuid();
            var commentDto = A.Fake<CommentForUpdateDto>();
            var comment = A.Fake<Comment>();          

            A.CallTo(() => _mapper.Map(commentDto, comment));           
            var controller = new CommentsController(_logger, _mapper, _repository);
            
            //Act
            var result = await controller.UpdateCommentForUser(id, userId,  commentDto);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async void CommentsController_DeleteCommentForUser_ReturnOk()
        {
            //Arrange
            int id = 1;
            Guid userId = Guid.NewGuid();           
            var controller = new CommentsController(_logger, _mapper, _repository);

            //Act
            var result = await controller.DeleteCommentForUser(id, userId);

            //Assert
            result.Should().NotBeNull();
        }
    }
}
