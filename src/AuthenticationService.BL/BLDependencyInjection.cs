using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace AuthenticationService.BL;

public static class BLDependencyInjection
{
    public static IServiceCollection AddBLLayer(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}