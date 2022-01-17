using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var marktContext = scope.ServiceProvider.GetRequiredService<MarktContext>();
                await MarktContextSeed.SeedAsync(marktContext);

                // Seed method
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();  
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                await AppIdentityDbContextSeed.SeedAsync(roleManager, userManager);


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
