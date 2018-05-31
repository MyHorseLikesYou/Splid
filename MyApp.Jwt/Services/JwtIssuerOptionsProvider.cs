using Microsoft.IdentityModel.Tokens;
using MyApp.Jwt.Interfaces;
using MyApp.Jwt.Models;
using System.Threading.Tasks;

namespace Auth.Application.Services
{
    public class JwtIssuerOptionsProvider : IJwtIssuerOptionsProvider
    {
        public Task<JwtIssuerOptions> GetAsync()
        {
            return Task.FromResult(new JwtIssuerOptions("", "", "", new SigningCredentials(null, "")));
        }
    }
}
