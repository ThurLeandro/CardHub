using Tournament.Domain.Entities;

public interface ITournamentRepository
{
    Task AddAsync(TournamentConf tournament);
    Task<IReadOnlyList<TournamentConf>> GetAllAsync();
    Task<TournamentConf?> GetByIdAsync(Guid id);
}


