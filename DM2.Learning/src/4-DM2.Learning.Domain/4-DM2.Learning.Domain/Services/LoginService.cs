using _4_DM2.Learning.Domain.Interfaces.Domains;
using _4_DM2.Learning.Domain.Interfaces.Repositories;
using _4_DM2.Learning.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _4_DM2.Learning.Domain.Services;

public class LoginService : ILoginService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRpository;

    public LoginService(IConfiguration configuration,
                        IUserRepository userRpository)
    {
        _configuration = configuration;
        _userRpository = userRpository;
    }

    public async Task<AuthenticateToken> Authenticate(string login, string password)
    {
        var authenticated = await _userRpository.ValidateUser(login, password);
        var jwtConfiguration = _configuration.GetSection("JWT");

        await Task.Delay(1);

        if (authenticated)
        {
            var issuer = jwtConfiguration.GetSection("Issuer").Value;
            var audience = jwtConfiguration.GetSection("Issuer").Value;
            var key = Encoding.ASCII.GetBytes
            (jwtConfiguration.GetSection("Key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, "daniel"),
                    new Claim(JwtRegisteredClaimNames.Email, "daniel"),
                    new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);

            return new AuthenticateToken() { Token = stringToken, Authenticate = true };
        }

        return new AuthenticateToken() { Authenticate = false };
    }
}
