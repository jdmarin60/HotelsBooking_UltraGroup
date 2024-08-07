using HotelsBooking.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ReservasHoteles.ConfigExtensions
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

            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<BookingDbContext>(options =>
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

            builder.Services.AddControllers();

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

            app.UseAuthentication();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllers();

            return app;
        }
    }
}
