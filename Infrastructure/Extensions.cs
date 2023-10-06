/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using Core.Repositories;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Infrastructure.EntityFramework;
using Infrastructure.Firebase;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<AuditableInterceptor>();   
        services.AddDbContext<WaiterDbContext>((sp,o) =>
        {
            string connectionString = configuration.GetConnectionString("WaiterApiDatabase");
            o.UseNpgsql(connectionString);
            o.AddInterceptors(sp.GetRequiredService<AuditableInterceptor>());
        });
        
        AddFirebase(services, configuration);
        services.RegisterRepositories();
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        return app;
    }
    private static void AddFirebase(IServiceCollection services, IConfiguration configuration)
    {
        var filePath = configuration.GetSection("Firebase:KeyPath");
        var firebase = FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile(filePath.Value),
        });

        
        services.AddSingleton(firebase);
        services.AddScoped<FirebaseAuthenticationFunctionHandler>();

        services.AddAuthentication()
                .AddScheme<FirebaseAuthenticationOptions, FirebaseAuthenticationHandler>(
                        JwtBearerDefaults.AuthenticationScheme, _ => { });
    }


    private static void RegisterRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IUnitOfWork,UnitOfWork>();
        serviceCollection.AddTransient<IOrderAggregateRepository,OrderAggregateRepository>();

    }
}

