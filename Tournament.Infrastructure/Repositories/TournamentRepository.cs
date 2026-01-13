using Microsoft.EntityFrameworkCore;
using Tournament.Domain.Entities;
using Tournament.Domain.Repositories;
using Tournament.Infrastructure.Persistence;

public class TournamentRepository : ITournamentRepository
{
    private readonly TournamentDbContext _context;

    public TournamentRepository(TournamentDbContext context)
    {
        _context = context;
    }

    public IQueryable<TournamentConf> Query()
        => _context.Tournaments.AsNoTracking();

    public async Task AddAsync(TournamentConf tournament)
    {
        _context.Tournaments.Add(tournament);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<TournamentConf?> GetByIdAsync(Guid id)
        => await _context.Tournaments.FindAsync(id);
}
