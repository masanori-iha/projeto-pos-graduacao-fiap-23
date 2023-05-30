using _3_DM2.Learning.Application.ViewModels;
using _4_DM2.Learning.Domain.Models;
using AutoMapper;

namespace _3_DM2.Learning.Application.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<AuthenticateToken, AuthenticateTokenViewModel>();
            CreateMap<AuthenticateTokenViewModel, AuthenticateToken>();
        }
    }
}
