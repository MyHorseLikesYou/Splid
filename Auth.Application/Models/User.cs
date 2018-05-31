using MyApp.Core.Domain;
using System;

namespace Auth.Application
{
    public class User : Entity
    {
        public readonly string _login;
        public readonly string _passwordHash;

        public User(Guid id, string login, string passwordHash)
            :base(id)
        {
            _login = login;
            _passwordHash = passwordHash;
        }

        public string Login => _login;

        public bool IsPasswordValid(string password)
        {
            throw new NotImplementedException();
        }
    }
}
