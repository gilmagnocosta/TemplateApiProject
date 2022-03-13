using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TemplateApiProject.Application.Data.Context
{
    public class DbContextFactory : IDesignTimeDbContextFactory<TemplateApiProjectDataContext>
    {
        public TemplateApiProjectDataContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<TemplateApiProjectDataContext>();

            var connectionString = configuration
                  .GetConnectionString("DatabaseConnection");
            
            Console.WriteLine($"Conexão: {connectionString}");

            dbContextBuilder.UseSqlServer(connectionString);

            return new TemplateApiProjectDataContext(dbContextBuilder.Options);
        }
    }
}
