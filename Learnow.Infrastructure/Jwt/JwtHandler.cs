using Learnow.Contract.Dto.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Learnow.Infrastructure.Jwt
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly JwtOptions _options;
        private readonly SecurityKey _issuerSigningKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtHeader _jwtHeader;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtHandler(JwtOptions options)
        {
            _options = options;
            _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey));
            _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(_signingCredentials);
            _tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = options.Issuer,
                IssuerSigningKey = _issuerSigningKey
            };

            Console.WriteLine($"JWTHandler Options: ${_options.Issuer} ${_options.SecretKey} : ${_options.ExpiryMinutes}");
        }

        public AuthTokenDto Create(string username)
        {
            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddMinutes(_options.ExpiryMinutes);
            var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            //var now = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
            //var payload = new JwtPayload
            //{
            //    { "sub", userId },
            //    { "iss", _options.Issuer },
            //    { "iat", nowUtc },
            //    { "exp", expires},
            //    { "unique_name", userId}
            //};

            //var jwt = new JwtSecurityToken(_jwtHeader, payload);
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: null,
                claims: new[]{
                    new Claim(ClaimTypes.Name, username)
                },
                expires: expires,
                signingCredentials: _signingCredentials
            );

            var token = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new AuthTokenDto
            {
                Token = token,
                Expires = expires
            };
        }
    }
}
