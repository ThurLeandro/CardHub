using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tournament.Application.Common;
using Tournament.Application.Tournaments.Responses;
using Tournament.Domain.Entities;
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
        var query = _repository.Query();

        if (game.HasValue)
            query = query.Where(t => t.Game == game.Value);

        if (status.HasValue)
            query = query.Where(t => t.Status == status.Value);

        query = (orderBy ?? "name").ToLower() switch
        {
            "name" => query.OrderBy(t => t.Name),
            "name_desc" => query.OrderByDescending(t => t.Name),

            "game" => query.OrderBy(t => t.Game),
            "game_desc" => query.OrderByDescending(t => t.Game),

            "status" => query.OrderBy(t => t.Status),
            "status_desc" => query.OrderByDescending(t => t.Status),

            _ => query.OrderBy(t => t.Name)
        };

        var totalItems = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(t => new TournamentResponse(
                t.Id,
                t.Name,
                t.Game,
                t.Status,
                t.TotalRounds
            ))
            .ToListAsync();

        return PagedResponse<TournamentResponse>.Create(
            items,
            page,
            pageSize,
            totalItems
        );
    }
}
