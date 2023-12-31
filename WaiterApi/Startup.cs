﻿/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */

using System;
using Application.Commands;
using Application.Queries;
using Common;
using Common.Dispatcher;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Waiter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
           
         
            services.AddRazorPages();

            services.RegisterQueryHandlers();
            services.RegisterCommandHandlers();
            services.RegisterCQRS();
            services.RegisterIdentityService();
            services.AddSwagger();            
           
            services.AddInfrastructure(Configuration);
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                
                endpoints.MapGet("/orders", (IDispatcher dispatcher) => dispatcher.RunAsync(new GetOrdersQuery()));
                endpoints.MapGet("/order/{id}", (IDispatcher dispatcher, Guid id) => dispatcher.RunAsync(new GetOrderQuery(id)));
                endpoints.MapPost("/orders", (IDispatcher dispatcher, [FromBody]CreateOrderCommand command) => dispatcher.RunAsync(command));
                endpoints.MapPost("/orders/addItem", (IDispatcher dispatcher, [FromBody]AddItemCommand command) => dispatcher.RunAsync(command));
                endpoints.MapPost("/orders/removeItem", (IDispatcher dispatcher, [FromBody]RemoveItemCommand command) => dispatcher.RunAsync(command));
                
                
                
            });

            app.UseSwaggerCommon();
            app.UseInfrastructure();
            
        }

    }
}

