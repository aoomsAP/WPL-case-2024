using FCentricProspections.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using FCentricProspections.Server.Services;
using System.Xml.Linq;

namespace FCentricProspections
{
    public class Startup
    {
        // The below method configures the depedency containers
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddScoped<IData, InMemoryData>();
            //services.AddScoped<IData, EfData>();

            // Database connection

            //var connection = "server=localhost; database=orchestra-db; user=root; password=password";

            // mySqlOptions / MigrationsAssembly necessary because DbContext is in class library
            // and this apparently causes migrations confusion
            //    // https://stackoverflow.com/questions/38705694/add-migration-with-different-assembly
            //    services.AddDbContext<DataContext>(x => x.UseMySql(
            //        connection,
            //        ServerVersion.AutoDetect(connection),
            //        mySqlOptions => mySqlOptions.MigrationsAssembly("MVC")));

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
                    ExceptionHandler = context => context.Response.WriteAsync("Er ging iets mis.")
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