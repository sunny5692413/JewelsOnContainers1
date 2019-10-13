using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductCatalogAPI.Data;

namespace ProductCatalogAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)//contructor with parameter
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var server = Configuration["DatabaseServer"];
             var database = Configuration["DatabaseName"];
             var user = Configuration["DatabaseUser"];
             var password = Configuration["DatabasePassword"];
             var connectionString = $"Server={server};Database={database};User ID={user};Password={password}";
             services.AddDbContext<CatalogContext>(options =>
             options.UseSqlServer(connectionString)); //create instance of DbContext,thisis where you have the flexibility of which database to choose
            
           // var connectionString = Configuration["ConnectionString"];
    services.AddSwaggerGen(options =>
          {
              options.DescribeAllEnumsAsStrings();
              options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info  //create an instance of swager
              {
                  Title = "JewelsOnContainers-- Product Catalog Http API",
                  Version = "v1",
                  Description = " Jewels Pruduct Catalog API",
                  TermsOfService = "Terms of service"

              }


              );



          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger()
                .UseSwaggerUI(c =>
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "ProductCatalogAPI v1"));
            //enable swagger give  access point,new instance of swagger dump into the folder with te name of ""
            app.UseMvc();
        }
    }
}
