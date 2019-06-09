using System.Threading.Tasks;

namespace Auth.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByLoginAsync(string login);
    }
}
