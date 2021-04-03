using AutoMapper;
using WebApi.Domain.Entities;
using WebApi.Domain.Models;

namespace WebApi.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ReverseMap();
        }
    }
}