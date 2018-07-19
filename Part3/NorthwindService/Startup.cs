using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NorthwindContextLib;
using Microsoft.EntityFrameworkCore;
using NorthwindService.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace NorthwindService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<Northwind>(options => options.UseSqlServer
                (System.IO.File.ReadAllText(".connectionString"))
            );

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", 
                            new Info{
                                Title ="Northwind Service API"
                                ,Version = "v1"
                            });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json"
                                ,"Northwind Service API v1");
            });
            app.UseMvc();
        }
    }
}
