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

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

            services.AddDbContext<EverestDBContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
            );

            return services;
        }
    }
}