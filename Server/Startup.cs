using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Server.Domains.Repositories;
using Server.Domains.Services;
using Server.Persistence.Contexts;
using Server.Persistence.Repositories;
using Server.Services;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Server", Version = "v1" });
            });

            var connection = Configuration["ConnectionSqlite:SqliteConnectionString"];

            services.AddDbContext<AppDbContext>(options =>
            {
                options.EnableDetailedErrors(true);
                options.UseSqlite(connection);
            });

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
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
