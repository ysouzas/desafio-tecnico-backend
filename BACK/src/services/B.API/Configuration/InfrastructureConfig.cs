using B.API.Infrastructure.Settings;

namespace B.API.Configuration;

public static class InfrastructureConfig
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<AdminSettings>(configuration.GetSection("AdminSettings"));
    }
}


