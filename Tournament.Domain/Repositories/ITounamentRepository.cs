using System.Linq;
using Tournament.Domain.Entities;

namespace Tournament.Domain.Repositories;

public interface ITournamentRepository
{
    IQueryable<TournamentConf> Query();

    Task AddAsync(TournamentConf tournament);
    Task SaveChangesAsync();
    Task<TournamentConf?> GetByIdAsync(Guid id);
}
