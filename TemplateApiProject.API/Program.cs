using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using TemplateApiProject.Application.Data.Context;

namespace TemplateApiProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Information("Starting Web API");


            var host = CreateHostBuilder(args).Build();
            //ExecuteMigrate(host);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((hostingContext, config) =>
            {
                config.ReadFrom.Configuration(hostingContext.Configuration);
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void ExecuteMigrate(IHost builder)
        {
            using (var scope = builder.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<TemplateApiProjectDataContext>();
                    //context.Database.Migrate();

                }
                catch (Exception ex)
                {
                    Serilog.Log.Error(ex, "An error occurred while migrating or seeding the database.");
                }
            }
        }
    }
}
