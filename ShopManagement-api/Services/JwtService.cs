using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopManagement_api.Configurations;
using ShopManagement_api.Interfaces.Services;
using ShopManagement_api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopManagement_api.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IConfiguration _configuration;

        public JwtService(IOptions<JwtSettings> jwtOptions, IConfiguration configuration)
        {
            _jwtSettings = jwtOptions.Value;
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            var expireMinutes = _configuration.GetValue<int>("JwtSettings:ExpireMinutes");


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        }),
                Expires = DateTime.UtcNow.AddMinutes(expireMinutes), 
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
