using API.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace API.Authentication
{
    public class TokenService : ITokenService
    {
        private TimeSpan ExpiryDuration = new TimeSpan(0, 40, 0);
        public string BuildToken(string key,string issuer,string user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user),
                //new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.NameIdentifier,
                Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims, expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }
    }
}
