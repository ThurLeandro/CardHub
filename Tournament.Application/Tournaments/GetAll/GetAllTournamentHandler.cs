using System.Net.NetworkInformation;
using Tournament.Application.Common;
using Tournament.Application.Tournaments.Responses;
using Tournament.Domain.Repositories;

namespace Tournament.Application.Tournaments.GetAll;

public class GetAllTournamentsHandler
{
    private readonly ITournamentRepository _repository;

    public GetAllTournamentsHandler(ITournamentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResponse<TournamentResponse>> Handle(
        int page = 1,
        int pageSize = 10,
        Game? game = null,
        TournamentStatus? status = null,
        string? orderBy = null)

    {
        var tournaments = await _repository.GetAllAsync();

        tournaments = orderBy?.ToLower() switch
        {
            "name" => tournaments.OrderBy(t => t.Name).ToList(),
            "name_desc" => tournaments.OrderByDescending(t => t.Name).ToList(),

            "game" => tournaments.OrderBy(t => t.Game).ToList(),
            "game_desc" => tournaments.OrderByDescending(t => t.Game).ToList(),

            "status" => tournaments.OrderBy(t => t.Status).ToList(),
            "status_desc" => tournaments.OrderByDescending(t => t.Status).ToList(),

            _ => tournaments.OrderBy(t => t.Name).ToList()
        };

        if (game.HasValue)
            tournaments = tournaments
                .Where(t => t.Game == game.Value)
                .ToList();

        if (status.HasValue)
            tournaments = tournaments
                .Where(t => t.Status == status.Value)
                .ToList();

        var totalItems = tournaments.Count;

        var items = tournaments
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(t => new TournamentResponse(
                t.Id,
                t.Name,
                t.Game,
                t.Status,
                t.TotalRounds
            ))
            .ToList();

        return PagedResponse<TournamentResponse>.Create(
            items,
            page,
            pageSize,
            totalItems
        );
    }
}