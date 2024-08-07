using Duende.IdentityServer;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.Models;
using IdentityServerNETIdentity.Data;
using IdentityServerNETIdentity.Helpers;
using IdentityServerNETIdentity.Models;
using IdentityServerNETIdentity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Cryptography.Xml;

namespace IdentityServerNETIdentity.ConfigExtensions
{
    internal static class HostingExtensions
    {
        readonly static string SpecificOrigins = "_specificOrigins";
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
            var configuration = builder.Configuration;

            var AppSettings = configuration.GetSection("AppSettings");
            builder.Services.Configure<AppSettings>(AppSettings);

            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            string? clientId = configuration["AppSettings:ClientId"];
            string? secret = configuration["AppSettings:Secret"];
            string? scope = configuration["AppSettings:Scope"];
            string? apiResource = configuration["AppSettings:ApiResource"];

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString)
                );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: SpecificOrigins, configurePolicy =>
                {
                    configurePolicy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddIdentityServer(options =>
                {
                    options.Authentication.CookieLifetime = TimeSpan.FromHours(12);
                })
                .AddDeveloperSigningCredential() // For development only
                .AddInMemoryClients(Config.GetClients(clientId, secret, scope))
                .AddInMemoryApiResources(Config.GetApiResources(apiResource, scope))
                .AddInMemoryApiScopes(Config.GetApiScopes(scope))
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryPersistedGrants()
                .AddAspNetIdentity<ApplicationUser>();

            builder.Services.AddControllers();
            
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddAuthentication();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(SpecificOrigins);

            app.UseIdentityServer();
            app.UseAuthentication();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllers();

            return app;
        }

        
    }
}