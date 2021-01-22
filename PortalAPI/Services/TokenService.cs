
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortalAPI.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortalAPI.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public object GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string secretKey = _configuration.GetValue<string>("JwtSettings:SecretKey");
            int tokenExpires = _configuration.GetValue<int>("JwtSettings:TokenExpires");
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(tokenExpires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenCreated = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tokenCreated);

            DateTime createdDate = DateTime.UtcNow;
            DateTime expiresDate = DateTime.UtcNow + TimeSpan.FromHours(tokenExpires);

            var auth = new
            {
                authenticated = true,
                created = createdDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expiresDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };

            return auth;
        }
    }
}
