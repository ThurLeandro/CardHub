using Tournament.Domain.Entities;
namespace Tournament.Application.Tournaments;
public record CreateTournamentCommand(
    string Name,
    Game Game,
    int TotalRounds
);

public class CreateTournamentHandler
{
    private readonly ITournamentRepository _repository;

    public CreateTournamentHandler(ITournamentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateTournamentCommand command)
    {
        var tournament = new TournamentConf(
            command.Name,
            command.Game,
            command.TotalRounds
        );

        await _repository.AddAsync(tournament);
        return tournament.Id;
    }
}

