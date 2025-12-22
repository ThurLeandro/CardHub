using Microsoft.EntityFrameworkCore;
using Tournament.Domain.Entities;
using Tournament.Infrastructure.Persistence;

public class TournamentRepository : ITournamentRepository
{
    private readonly TournamentDbContext _context;

    public TournamentRepository(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TournamentConf tournament)
    {
        _context.Tournaments.Add(tournament);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<TournamentConf>> GetAllAsync()
        => await _context.Tournaments.ToListAsync();

    public async Task<TournamentConf?> GetByIdAsync(Guid id)
        => await _context.Tournaments.FindAsync(id);
}
