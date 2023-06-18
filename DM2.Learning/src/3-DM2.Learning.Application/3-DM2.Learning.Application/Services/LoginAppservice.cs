using _3_DM2.Learning.Application.interfaces;
using _3_DM2.Learning.Application.ViewModels;
using _4_DM2.Learning.Domain.Interfaces.Domains;
using AutoMapper;

namespace _3_DM2.Learning.Application.Services;

public class LoginAppService : ILoginAppService
{
    private readonly IMapper _mapper;
    private readonly ILoginService _loginService;

    public LoginAppService(IMapper mapper, ILoginService loginService)
    {
        _mapper = mapper;
        _loginService = loginService;
    }

    public async Task<AuthenticateTokenViewModel> Authenticate(string login, string password)
    {
        return _mapper.Map<AuthenticateTokenViewModel>(await _loginService.Authenticate(login, password));
    }
}
