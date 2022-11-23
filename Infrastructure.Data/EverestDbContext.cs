using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class EverestDBContext : DbContext
    {
        public EverestDBContext(DbContextOptions<EverestDBContext> dbContextOptions) : base(dbContextOptions) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Infrastructure.Data"));

        }
    }
}
