using System.Reflection;
using B.API.Data;
using B.API.Data.Repository;
using B.API.Data.Repository.Interfaces;

namespace B.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<ApiContext>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
