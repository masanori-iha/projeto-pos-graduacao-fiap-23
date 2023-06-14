using _4_DM2.Learning.Domain.Entities;
using _4_DM2.Learning.Domain.Interfaces.Domains;
using _4_DM2.Learning.Domain.Interfaces.Repositories;
using _4_DM2.Learning.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace _3_DM2.Learning.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRpository _userRpository;

        public UserService(IConfiguration configuration,
                            IUserRpository userRpository)
        {
            _configuration = configuration;
            _userRpository = userRpository;
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _userRpository.GetUserByName(name);
        }
    }
}
