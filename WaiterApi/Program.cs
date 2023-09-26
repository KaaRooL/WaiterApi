/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Waiter
{
    public class Program
    {
        public static Task Main(string[] args) => CreateHostBuilder(args).Build().RunAsync();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args).ConfigureAppConfiguration(options =>
                    {
                        options.AddEnvironmentVariables(prefix: "WaiterApi__");
                    })
                    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
