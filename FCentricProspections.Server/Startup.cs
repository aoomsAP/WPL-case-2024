using FCentricProspections.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using FCentricProspections.Server.Services;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FCentricProspections
{
    public class Startup
    {
        // The below method configures the depedency containers
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddScoped<IData, EfData>();

            // Database connection
            var connection = "server=localhost; database=FCentricSmall; Trusted_Connection=true; Encrypt=Yes; TrustServerCertificate=Yes;";
            services.AddDbContext<FCentricSmallContext>(options => options.UseSqlServer(connection));
        }

        // The below method gets called by runtime
        // It configures the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Development
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = String.Empty;
                });
            }
            // Production 
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context => context.Response.WriteAsync("Something went wrong.")
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}