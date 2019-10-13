using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductCatalogAPI.Data;

namespace ProductCatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host =CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())//dispose the scope object when the job is done, my host get me all the services
            {
              var services = scope.ServiceProvider;//give me all the service provider 
              var context=services.GetRequiredService<CatalogContext>();//tell me if the catalogcontext service is ready 
                CatalogSeeds.Seed(context); //if i have contextmeans my database is ready, i take than and give to my seed

            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)//host means makeing it available 
                .UseStartup<Startup>();
    }
}
