using AutoMapper;
using BLL.DTO;
using DAL;

namespace BLL.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenreDTO, Genre>();//.ForMember("Id", opt => opt.MapFrom(src => src));
            CreateMap<Genre, GenreDTO>();//.ForMember("Id", opt => opt.MapFrom(src => src));
        }
    }
}
