using Contracts;
using ipo.Data;
using ipo.Middlewares;
using Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipo.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureCors(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureDatabase(this IServiceCollection service, IConfiguration Configuration)
        {
            service.AddDbContext<ApplicationContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging());
        }

        public static void ConfigureLogger(this IServiceCollection service)
        {
            service.AddSingleton<LoggerManager, LogService>();
        }
    
        public static void ConfigureGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
