using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoanSimPriceAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace LoanSimPriceAPI.Services;

public class AuthService(IConfiguration configuration) : IAuthService
{
    public string GenerateJwtToken(string username)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}