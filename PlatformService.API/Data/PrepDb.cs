using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.API.Models;
using System;
using System.Linq;

namespace PlatformService.API.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (context.Platforms.Any() is false)
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange
                    (
                        new Platform() { Name = ".NET", Publisher = "Microsoft", Cost = "Free" },
                        new Platform() { Name = "SQL Sqrver Express", Publisher = "Microsoft", Cost = "Free" },
                        new Platform() { Name = "Kubernetes", Publisher = "Cloud native computing foundation", Cost = "Free" }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
