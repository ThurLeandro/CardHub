using System;
using System.Collections.Generic;
using System.Text;
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

    public async Task<IReadOnlyList<TournamentConf>> Handle()
    {
        var tournaments = await _repository.GetAllAsync();
        return tournaments;
    }
}

