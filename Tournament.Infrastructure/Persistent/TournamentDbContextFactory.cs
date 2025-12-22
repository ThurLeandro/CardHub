using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tournament.Infrastructure;

namespace Tournament.Infrastructure.Persistence
{
    public class TournamentDbContextFactory
        : IDesignTimeDbContextFactory<TournamentDbContext>
    {
        public TournamentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TournamentDbContext>();

            var connectionString =
                "Host=db;Port=5432;Database=tournament;Username=postgres;Password=postgres";

            optionsBuilder.UseNpgsql(connectionString);

            return new TournamentDbContext(optionsBuilder.Options);
        }
    }
}
