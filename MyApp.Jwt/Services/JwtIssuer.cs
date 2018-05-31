using MyApp.Core.Extensions;
using MyApp.Jwt.Interfaces;
using MyApp.Jwt.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyApp.Jwt.Services
{
    public class JwtIssuer : IJwtIssuer
    {
        private readonly IJwtIssuerOptionsProvider _jwtIssuerOptionsProvider;

        public JwtIssuer(IJwtIssuerOptionsProvider jwtIssuerOptionsProvider)
        {
            _jwtIssuerOptionsProvider = jwtIssuerOptionsProvider;
        }

        public async Task<JwtToken> GenerateToken(string jti, string sub, ClaimsIdentity identity)
        {
            var jwtOptions = await _jwtIssuerOptionsProvider.GetAsync();
            var issuedAt = DateTime.UtcNow;

            //create claims            

            var iat = issuedAt
                .ToUnixEpochDate()
                .ToString();            

            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Sub, sub),
                 new Claim(JwtRegisteredClaimNames.Jti, jti),
                 new Claim(JwtRegisteredClaimNames.Iat, iat, ClaimValueTypes.Integer64),
             };

            claims.AddRange(identity.Claims);

            //create encoded token

            var expires = issuedAt
                .Add(jwtOptions.NotBefore)
                .Add(jwtOptions.ValidFor);

            var jwt = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                notBefore: issuedAt.Add(jwtOptions.NotBefore),
                expires: expires,
                signingCredentials: jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtToken(encodedJwt, (int)jwtOptions.ValidFor.TotalSeconds);
        }
    }
}
