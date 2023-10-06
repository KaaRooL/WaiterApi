﻿/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using Common.Dispatcher;
using Common.Dispatcher.CommandProcessor;
using Common.Dispatcher.QueryProcessor;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Common;

public static class Extensions
{

    public static void RegisterIdentityService(this IServiceCollection services)
    {
        services.AddTransient<IIdentityService, IdentityService>();
    }
    public static void RegisterCQRS(this IServiceCollection services)
    {
        services.AddTransient<IDispatcher, Dispatcher.Dispatcher>();
        services.AddTransient<IQueryProcessor, QueryProcessor>();
        services.AddTransient<ICommandProcessor, CommandProcessor>();
    }
    public static void RegisterCommandHandlers(this IServiceCollection services)
        {
            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(ICommandHandlerAsync<>))
                                                 .Where(c => c is { IsAbstract: false, IsGenericTypeDefinition: false }))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));

            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(ICommandHandlerAsync<,>))
                                                 .Where(c => c is { IsAbstract: false, IsGenericTypeDefinition: false }))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));

            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(ICommandHandler<>))
                                                 .Where(c => c is { IsAbstract: false, IsGenericTypeDefinition: false }))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));

            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(ICommandHandler<,>))
                                                 .Where(c => c is { IsAbstract: false, IsGenericTypeDefinition: false }))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));
        }

        public static void RegisterQueryHandlers(this IServiceCollection services)
        {
            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(IQueryHandlerAsync<,>))
                                                 .Where(c => c is { IsAbstract: false, IsGenericTypeDefinition: false }))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));

            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(IQueryHandler<,>))
                                                 .Where(c => c is { IsAbstract: false, IsGenericTypeDefinition: false }))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));
        }
        
        public static void UseSwaggerCommon(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Common API", Version = "v1", Description = "Common Api created by Karol Siwak", });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }
}
