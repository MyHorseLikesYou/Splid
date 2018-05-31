using Auth.Application.Models;
using MyApp.Jwt.Models;
using System.Threading.Tasks;

namespace Auth.Application.Interfaces
{
    public interface IAuthService
    {        
        Task<JwtToken> CreateAccessTokenAsync(UserCredentials credentials);
    }
}
