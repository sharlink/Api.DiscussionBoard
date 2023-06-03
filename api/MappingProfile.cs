using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CommentForCreationDto, Comment>();

            CreateMap<Comment, CommentDto>();                          

            CreateMap<CommentForUpdateDto, Comment>();

            //CreateMap<CompanyForCreationDto, Company>();

            //CreateMap<EmployeeForCreationDto, Employee>();

            //CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

            //CreateMap<CompanyForUpdateDto, Company>();
        }
    }
}
