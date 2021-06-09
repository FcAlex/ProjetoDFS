using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Server.Domains.Repositories;
using Server.Domains.Services;
using Server.Persistence.Contexts;
using Server.Persistence.Repositories;
using Server.Services;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            Cors(services);
            DbContext(services);
            Scopes(services);
            Authentication(services);

            services.AddAutoMapper(typeof(Startup));
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void Cors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        private static void Scopes(IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private void Authentication(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
               opt =>
               {
                   var s = Encoding.UTF8.GetBytes(Configuration["SecurityKey"]);
                   opt.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Issuer"],
                       ValidAudience = Configuration["Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(s)
                   };

                   opt.Events = new JwtBearerEvents
                   {
                       OnAuthenticationFailed = _ => Task.CompletedTask,
                       OnTokenValidated = _ => Task.CompletedTask
                   };
               });
        }

        private void DbContext(IServiceCollection services)
        {
            var connection = Configuration["ConnectionSqlite:SqliteConnectionString"];

            services.AddDbContext<AppDbContext>(options =>
            {
                options.EnableDetailedErrors(true);
                options.UseSqlite(connection);
            });
        }
    }
}
