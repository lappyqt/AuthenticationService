using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AuthenticationService.DAL.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationService.DAL;

public static class DALDependencyInjection 
{
    public static IServiceCollection AddDALLayer(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddDatabase(configuration);
        return services;
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")));
    }
}