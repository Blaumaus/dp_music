using AutoMapper;
using BLL.DTO;
using DAL;
using System.Collections.Generic;

namespace BLL.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenreDTO, Genre>();//.ForMember("Id", opt => opt.MapFrom(src => src));
            CreateMap<Genre, GenreDTO>();//.ForMember("Id", opt => opt.MapFrom(src => src));
            CreateMap<UserRegistrationDto, User>().ForMember("Login",opt=>opt.MapFrom(src=>src.UserName));
            CreateMap<User, UserRegistrationDto>().ForMember("UserName", opt => opt.MapFrom(src => src.Login));
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Band, BandDto>();
            CreateMap<BandDto, Band>();
            CreateMap<Bandgenre, BandgenreDto>();
            CreateMap<BandgenreDto, Bandgenre>();
            CreateMap<Band, IEnumerable<BandDto>>();
        }
    }
}
