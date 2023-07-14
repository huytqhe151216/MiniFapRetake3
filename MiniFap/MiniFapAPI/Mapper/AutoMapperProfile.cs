

using AutoMapper;
using MiniFapAPI.DTO;
using MiniFapAPI.Models;

namespace MiniFapAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
        }
    }
}
