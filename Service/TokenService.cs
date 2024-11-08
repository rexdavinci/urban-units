using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using fractionalized.Interfaces;
using fractionalized.Models;
using Microsoft.IdentityModel.Tokens;

namespace fractionalized.Service
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        private readonly SymmetricSecurityKey _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SigningKey"]));
        private readonly IConfiguration _config = config;

        public string CreateToken(Subscriber subscriber)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, subscriber.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, subscriber.UserName),
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}