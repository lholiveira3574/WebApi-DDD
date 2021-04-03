using AutoMapper;
using WebApi.Domain.Dtos.User;
using WebApi.Domain.Models;

namespace WebApi.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>()
                .ReverseMap();

             CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();

             CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();
        }
    }
}