using EccomersAPI.DataAbstraction;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
namespace EccomersAPI.Services
{
    public class AuthService : IAuthService
    {
        IAuthSettings _settings;
        SymmetricSecurityKey key;
        SigningCredentials creds;
        public AuthService(IAuthSettings authSettings)
        {
            _settings = authSettings;
            this.key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            this.creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }
        public string GenerateAccessToken(string id, string email, IRole role)
        {
            var claims = new List<Claim> {
                new Claim("Id",id),
                new Claim("Email",email),
                new Claim("Role",role.ToString()),
                new Claim("TokenType","AccesToken")
            };
            var token = CreateToken(claims,DateTime.UtcNow.AddMinutes(_settings.AccesTokenLifeTime));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken(string id)
        {
            var claims = new List<Claim> {
                new Claim("Id",id),
                new Claim("TokenType","RefreshToken")
            };
            var token = CreateToken(claims, DateTime.UtcNow.AddDays(_settings.RefreshTokenLifeTime));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private JwtSecurityToken CreateToken(List<Claim> claims, DateTime expDate)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: new List<Claim>(claims),
                expires: expDate,
                signingCredentials: creds);
            return token;
        }
    }
}
