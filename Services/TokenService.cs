using AuthApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi.Services;

public static class TokenService
{
	public static string GenerateToken(User user)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		var key = Encoding.ASCII.GetBytes(Settings.Secret);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Expires = DateTime.UtcNow.AddHours(4),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
			Subject = new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Name, user.Username),
				new Claim(ClaimTypes.Role, user.Role)
			})
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}
