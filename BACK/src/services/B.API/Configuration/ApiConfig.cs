﻿using B.API.Data;
using B.API.Infrastructure.Filters;
using Microsoft.EntityFrameworkCore;

namespace B.API.Configuration;

public static class ApiConfig
{
    public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddDatabase(configuration);

        services.AddControllers(options =>
        {
            options.Filters.Add(new LogFilterAttribute());
        });

        services.AddCors(options =>
        {
            options.AddPolicy("Total",
                builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddJWTAuthentication(configuration);
    }

    public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("Total");

        app.UseAuthorization();

        app.MapControllers();
        app.AddMigrations();
    }

}

