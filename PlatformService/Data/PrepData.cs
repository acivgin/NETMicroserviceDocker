using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepData
    {
        public static void PrepDBData(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);
            }
        }
        private static void SeedData(AppDbContext context, bool isProduction)
        {
            if (isProduction)
            {
                Console.WriteLine("==> Attempting apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not run migration {ex.Message}");
                }
            }

            if (!context.Platforms.Any())
            {
                Console.WriteLine("==> Seeding Data");
                context.Platforms.AddRange(
                new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "Kubernates", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("==> We Already Have Data");
            }
        }
    }
}