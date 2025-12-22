namespace Tournament.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Tournament.Domain.Entities;

    public class TournamentDbContext : DbContext
    {
        public TournamentDbContext(DbContextOptions<TournamentDbContext> options)
            : base(options) { }

        public DbSet<TournamentConf> Tournaments => Set<TournamentConf>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<TournamentPlayer> TournamentPlayers => Set<TournamentPlayer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TournamentDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
