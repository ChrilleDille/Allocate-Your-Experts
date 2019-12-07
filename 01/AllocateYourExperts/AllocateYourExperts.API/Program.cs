using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllocateYourExperts.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AllocateYourExperts.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AYEDbContext>();
                // this is just one way of loading the data during the development of the application
                // Ensure Deleted make sure everything we made or changed during last debug will disappear
                // and we can start with just the seed data , see AYEDbContext.cs
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
