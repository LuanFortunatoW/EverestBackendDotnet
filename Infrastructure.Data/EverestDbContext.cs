using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EverestDBContext : DbContext
    {
        public EverestDBContext(DbContextOptions<EverestDBContext> dbContextOptions) : base(dbContextOptions) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EverestDBContext).Assembly);
        }
    }
}
