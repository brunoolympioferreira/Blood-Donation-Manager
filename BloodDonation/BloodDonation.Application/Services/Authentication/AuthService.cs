using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BloodDonation.Application.Services.Authentication;
public class AuthService : IAuthService
{
    public string ComputeSha256Hash(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        StringBuilder builder = new();

        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }

        return builder.ToString();
    }

    public string GenerateJwtToken(Core.Entities.User user)
    {
        var issuer = Environment.GetEnvironmentVariable("BloodDonation_Issuer");
        var audience = Environment.GetEnvironmentVariable("BloodDonation_Audience");
        var key = Environment.GetEnvironmentVariable("BloodDonation_Key");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims =
        [
            new("user_name", user.Name),
            new("email", user.Email),
            new("user_id", user.Id.ToString())
        ];

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddHours(12),
            signingCredentials: credentials,
            claims: claims);

        var tokenHandler = new JwtSecurityTokenHandler();

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
}
