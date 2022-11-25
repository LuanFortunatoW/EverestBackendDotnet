using EntityFrameworkCore.UnitOfWork.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.Data
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EverestDBContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            services.AddScoped<DbContext, EverestDBContext>();

            services.AddUnitOfWork<EverestDBContext>();

            return services;
        }
    }
}