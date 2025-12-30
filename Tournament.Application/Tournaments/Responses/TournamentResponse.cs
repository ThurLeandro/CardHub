using System;
using System.Collections.Generic;
using System.Text;

namespace Tournament.Application.Tournaments.Responses;
public record TournamentResponse(
    Guid Id,
    string Name,
    Game Game,
    TournamentStatus Status,
    int TotalRounds
);

