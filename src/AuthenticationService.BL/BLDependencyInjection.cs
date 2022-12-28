using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AuthenticationService.BL.Services;
using AuthenticationService.BL.Services.Impl;

namespace AuthenticationService.BL;

public static class BLDependencyInjection
{
    public static IServiceCollection AddBLLayer(this IServiceCollection services, IWebHostEnvironment environment)
    {
		services.AddServices(environment);
        return services;
    }

	public static void AddServices(this IServiceCollection services, IWebHostEnvironment environment)
	{
		services.AddScoped<IAccountService, AccountService>();
	}
}