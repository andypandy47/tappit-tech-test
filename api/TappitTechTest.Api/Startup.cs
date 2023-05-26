using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TappitTechTest.Core.Interfaces;
using TappitTechTest.Core.Interfaces.Repositories;
using TappitTechTest.Core.Interfaces.Services;
using TappitTechTest.Infrastructure;
using TappitTechTest.Infrastructure.Repositories;
using TappitTechTest.Infrastructure.Services;

namespace Tappit.Api
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
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TappitTechTest API"
                });
            });

            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IFavouriteSportsRepository, FavouriteSportsRepository>();
            services.AddScoped<ISportsRepository, SportsRepository>();
            services.AddScoped<IPeopleService, PeopleService>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
                app.UseCors(options =>
                {
                    options.WithOrigins("http://localhost:3000");
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
