using Tournament.Domain.Entities;
namespace Tournament.Domain.Repositories;

public interface ITournamentRepository
{
    Task AddAsync(TournamentConf tournament);
    Task<IReadOnlyList<TournamentConf>> GetAllAsync();
    Task<TournamentConf?> GetByIdAsync(Guid id);
    Task SaveChangesAsync();
}


