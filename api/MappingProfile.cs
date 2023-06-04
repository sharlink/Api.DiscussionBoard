using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CommentForCreationDto, Comment>();

            CreateMap<Comment, CommentDto>();

            CreateMap<CommentForUpdateDto, Comment>();            
        }
    }    
}
