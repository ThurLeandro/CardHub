using Tournament.Domain.Entities;
namespace Tournament.Application.Tournaments.Create;
public record CreateTournamentCommand(
    string Name,
    Game Game,
    int TotalRounds
);

