using Auth.Application.Exceptions;
using Auth.Application.Interfaces;
using Auth.Application.Models;
using Auth.Application.Validations;
using FluentValidation;
using MyApp.Jwt.Constants;
using MyApp.Jwt.Interfaces;
using MyApp.Jwt.Models;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Auth.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserCredentials> _userCredentialsValidator;
        private readonly IJwtIssuer _jwtIssuer;

        public AuthService(IUserRepository userRepository, IJwtIssuer jwtIssuer)
        {
            _userRepository = userRepository;
            _jwtIssuer = jwtIssuer;

            _userCredentialsValidator = new UserCredentialsValidator();
        }

        public async Task<JwtToken> CreateAccessTokenAsync(UserCredentials credentials)
        {
            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            var validationResult = await _userCredentialsValidator.ValidateAsync(credentials);
            if (!validationResult.IsValid)
                throw new InvalidUserCredentialsExceptions(validationResult.Errors);

            var user = await _userRepository.FindByLoginAsync(credentials.Login);
            if (user == null)
                throw new InvalidLoginOrPasswordException();

            if (!user.IsPasswordValid(credentials.Password))
                throw new InvalidLoginOrPasswordException();

            var tokenId = Guid.NewGuid().ToString();

            return await this.GenerateJwtToken(tokenId, user);
        }

        private async Task<JwtToken> GenerateJwtToken(string jti, User user)
        {
            var claims = new[]
            {
                new Claim(JwtCustomClaimNames.Id, user.Id.ToString()),
                new Claim(JwtCustomClaimNames.Rol, JwtCustomClaimValues.ApiAccess)
            };

            var identity = new ClaimsIdentity(new GenericIdentity(user.Login, "Token"), claims);

            return await _jwtIssuer.GenerateToken(jti: jti, sub: user.Login, identity: identity);
        }
    }
}
