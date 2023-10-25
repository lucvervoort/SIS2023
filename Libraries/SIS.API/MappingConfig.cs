using AutoMapper;
using SIS.API.DTO;
using SIS.Domain;

namespace SIS.API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
        }
    }
}
