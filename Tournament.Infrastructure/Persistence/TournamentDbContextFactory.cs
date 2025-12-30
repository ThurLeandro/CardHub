using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Tournament.Infrastructure.Persistence
{
    public class TournamentDbContextFactory
        : IDesignTimeDbContextFactory<TournamentDbContext>
    {
        public TournamentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TournamentDbContext>();

            optionsBuilder.UseNpgsql(
             Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
             ?? "Host=db;Port=5432;Database=tournament;Username=postgres;Password=postgres"
 );

            return new TournamentDbContext(optionsBuilder.Options);
        }
    }
}
