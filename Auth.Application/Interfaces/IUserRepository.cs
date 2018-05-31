using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByLoginAsync(string login);
    }
}
