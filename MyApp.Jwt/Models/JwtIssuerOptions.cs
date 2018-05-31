using Microsoft.IdentityModel.Tokens;
using System;

namespace MyApp.Jwt.Models
{
    public class JwtIssuerOptions
    {
        public JwtIssuerOptions(string issuer, string subject, string audience, SigningCredentials signingCredentials)
            : this(issuer, subject, audience, TimeSpan.FromSeconds(0), TimeSpan.FromMinutes(120), signingCredentials)
        { }

        public JwtIssuerOptions(string issuer, string subject, string audience, TimeSpan notBefore, TimeSpan validFor, SigningCredentials signingCredentials)
        {
            if (notBefore < TimeSpan.Zero)
                throw new ArgumentException("Must be a no negative TimeSpan.", nameof(JwtIssuerOptions.ValidFor));

            if (validFor <= TimeSpan.Zero)
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));

            if (signingCredentials == null)
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));

            Issuer = issuer;
            Subject = subject;
            Audience = audience;

            NotBefore = notBefore;            
            ValidFor = validFor;

            SigningCredentials = signingCredentials;
        }

        /// <summary>
        /// 4.1.1.  "iss" (Issuer) Claim - The "iss" (issuer) claim identifies the principal that issued the JWT.
        /// </summary>
        public string Issuer { get; private set; }

        /// <summary>
        /// 4.1.2.  "sub" (Subject) Claim - The "sub" (subject) claim identifies the principal that is the subject of the JWT.
        /// </summary>
        public string Subject { get; private set; }

        /// <summary>
        /// 4.1.3.  "aud" (Audience) Claim - The "aud" (audience) claim identifies the recipients that the JWT is intended for.
        /// </summary>
        public string Audience { get; private set; }

        /// <summary>
        /// Set the timespan before which the token NOT be accepted for processing. (default is 0 sec) 
        /// </summary>
        public TimeSpan NotBefore { get; private set; }

        /// <summary>
        /// Set the timespan the token will be valid for (default is 120 min)
        /// </summary>
        public TimeSpan ValidFor { get; private set; }

        /// <summary>
        /// The signing key to use when generating tokens.
        /// </summary>
        public SigningCredentials SigningCredentials { get; private set; }
    }
}
