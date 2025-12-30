using Tournament.Domain.Entities;
using Tournament.Domain.Repositories;
namespace Tournament.Application.Tournaments.Create;

public class CreateTournamentHandler
{
    private readonly ITournamentRepository _repository;

    public CreateTournamentHandler(ITournamentRepository repository)
    {
        _repository = repository;
    }

    public async Task<TournamentConf> Handle(CreateTournamentCommand command)
    {
        var tournament = new TournamentConf(
            command.Name,
            command.Game,
            command.TotalRounds
        );

        await _repository.AddAsync(tournament);
        await _repository.SaveChangesAsync();
        return tournament;
    }
}