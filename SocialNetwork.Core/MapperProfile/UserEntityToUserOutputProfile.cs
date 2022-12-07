using AutoMapper;
using SocialNetwork.Data.Entities;
using SocialNetwork.Models.Output;

namespace SocialNetwork.Core.MapperProfile
{
    public class UserEntityToUserOutputProfile : Profile
    {
        public UserEntityToUserOutputProfile()
        {
            CreateMap<UserEntity, UserOutput>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => "****"))
                    .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                    .ForMember(dest => dest.RegisterDate, opt => opt.MapFrom(src => src.RegisterDate));
        }
    }
}
