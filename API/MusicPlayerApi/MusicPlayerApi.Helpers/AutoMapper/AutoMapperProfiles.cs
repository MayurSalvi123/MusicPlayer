using AutoMapper;
using MusicPlayerApi.Core.Dtos;
using MusicPlayerApi.Core.Entities;

namespace MusicPlayerApi.Helpers.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
