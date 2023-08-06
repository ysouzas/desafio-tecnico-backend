using B.API.Data;
using Microsoft.EntityFrameworkCore;

namespace B.API.Configuration;

public static class DatabaseConfig
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApiContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void AddMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        try
        {
            var context = scope.ServiceProvider.GetRequiredService<ApiContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}

