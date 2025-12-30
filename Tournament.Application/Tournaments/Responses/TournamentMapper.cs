using Tournament.Application.Tournaments.Responses;
using Tournament.Domain.Entities;

public static class TournamentMapper
{
    public static TournamentResponse ToResponse(TournamentConf tournament)
    {
        return new TournamentResponse(
            tournament.Id,
            tournament.Name,
            tournament.Game,
            tournament.Status,
            tournament.TotalRounds
        );
    }
}
