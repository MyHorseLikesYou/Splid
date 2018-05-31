using MyApp.Jwt.Models;
using System.Threading.Tasks;

namespace MyApp.Jwt.Interfaces
{
    public interface IJwtIssuerOptionsProvider
    {
        Task<JwtIssuerOptions> GetAsync();
    }
}
