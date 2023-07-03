using _3_DM2.Learning.Application.ViewModels;
using _4_DM2.Learning.Domain.Entities;
using _4_DM2.Learning.Domain.Models;
using AutoMapper;

namespace _3_DM2.Learning.Application.AutoMapper;

public class DomainToViewModel : Profile
{
    public DomainToViewModel()
    {
        CreateMap<AuthenticateToken, AuthenticateTokenViewModel>();
        CreateMap<AuthenticateTokenViewModel, AuthenticateToken>();
        CreateMap<UserViewModel, User>()
            .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.UserImage)).ReverseMap();
        CreateMap<UserImageUpdateViewModel, User>()
            .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.UserImage)).ReverseMap();

        CreateMap<UserImageViewModel, UserImage>().ReverseMap();
    }
}
