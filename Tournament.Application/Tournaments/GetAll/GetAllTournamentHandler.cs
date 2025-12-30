using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Domain.Repositories;
using Tournament.Application.Tournaments.Responses;

namespace Tournament.Application.Tournaments.GetAll;
public class GetAllTournamentsHandler
{
    private readonly ITournamentRepository _repository;

    public GetAllTournamentsHandler(ITournamentRepository repository)
    {
        _repository = repository;
    }

    public async Task<TournamentResponse?> Handle()
    {
        var tournament = await _repository.GetAllAsync();
        return tournament is null ? null : TournamentMapper.ToResponse((Domain.Entities.TournamentConf)tournament);
    }
}

