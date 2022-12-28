using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthenticationService.Core.Entities;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public static class JwtHelper
{
	public static string GenerateToken(Account account, IConfiguration configuration)
	{
		var secretKey = configuration.GetValue<string>("JwtConfiguration:SecretKey");
		var key = Encoding.ASCII.GetBytes(secretKey);
		var tokenHandler = new JwtSecurityTokenHandler();

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new[]
			{
				new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
				new Claim(ClaimTypes.Name, account.Username),
				new Claim(ClaimTypes.Email, account.Email)
			}),

			Expires = DateTime.UtcNow.AddDays(16),
			SigningCredentials =
				new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}