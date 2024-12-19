using EatLess.Domain.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Infrastructure.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> jwtOptions)
        {
            _options = jwtOptions.Value;
        }
        public string GetJwtToken(string UserId, string Email)
        {
            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sub , UserId),
                new(JwtRegisteredClaimNames.Email , Email)
            };
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _options.Issuer, 
                _options.Audience, 
                claims, 
                null, 
                DateTime.Now.AddHours(1), 
                signingCredentials);
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
