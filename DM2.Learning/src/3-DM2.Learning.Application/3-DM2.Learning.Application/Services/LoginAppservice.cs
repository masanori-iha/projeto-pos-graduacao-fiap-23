using _3_DM2.Learning.Application.interfaces;
using _3_DM2.Learning.Application.ViewModels;
using _4_DM2.Learning.Domain.Interfaces.Domains;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DM2.Learning.Application.Services
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IMapper _mapper;
        private readonly ILoginService _loginService;

        public LoginAppService(ILoginService loginService,
                               IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        public async Task<AuthenticateTokenViewModel> Authenticate(string login, string password)
        {
            return _mapper.Map<AuthenticateTokenViewModel>(await _loginService.Authenticate(login, password));
        }
    }
}
