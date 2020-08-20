using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DBAccessSample.Data;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace DBAccessSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new HostBuilder()
       .UseContentRoot(Directory.GetCurrentDirectory())
       .ConfigureWebHostDefaults(webBuilder =>
       {
           webBuilder.UseKestrel(serverOptions =>
           {
                // Set properties and call methods on options
            })
           .UseIISIntegration()
           .UseStartup<Startup>();
       })
       .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MyDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }
    }
}
