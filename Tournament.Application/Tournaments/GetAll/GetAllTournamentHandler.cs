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
        int pageSize = 10)
    {
        var tournaments = await _repository.GetAllAsync();

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