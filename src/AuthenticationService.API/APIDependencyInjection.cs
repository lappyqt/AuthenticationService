using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.API;

public static class APIDependencyInjection
{
	public static void AddJWT(this IServiceCollection services, IConfiguration configuration)
	{
		var secretKey = configuration.GetValue<string>("JwtConfiguration:SecretKey");
		var key = Encoding.ASCII.GetBytes(secretKey);

		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(options =>
		{
			options.SaveToken = true;
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = false,
				ValidateAudience = false
			};
		});
	}
}