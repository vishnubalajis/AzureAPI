using AzureAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AzureAPI.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        public TokenService(IConfiguration configuratin)
        {
            this.configuration = configuratin;
        }
        public string CreateToken(UserClaimsDto userClaims)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,userClaims.EmployeeName ?? string.Empty),
                new Claim(ClaimTypes.Role,userClaims.EmployeeRole ?? string.Empty),
                new Claim(ClaimTypes.Email,userClaims.EmployeeEmail ?? string.Empty),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var tokens = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokens);
        }
    }
}
