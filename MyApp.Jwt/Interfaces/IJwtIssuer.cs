using MyApp.Jwt.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyApp.Jwt.Interfaces
{
    public interface IJwtIssuer
    {
        Task<JwtToken> GenerateToken(string jti, string sub, ClaimsIdentity identity);
    }
}
