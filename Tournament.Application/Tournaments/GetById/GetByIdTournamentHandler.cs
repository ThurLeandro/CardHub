using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Application.Tournaments.Responses;
using Tournament.Domain.Repositories;

namespace Tournament.Application.Tournaments.GetById;
public class GetTournamentByIdHandler
{
    private readonly ITournamentRepository _repository;

    public GetTournamentByIdHandler(ITournamentRepository repository)
    {
        _repository = repository;
    }

    public async Task<TournamentResponse?> Handle(Guid id)
    {
        var tournament = await _repository.GetByIdAsync(id);
        return tournament is null ? null : TournamentMapper.ToResponse(tournament);
    }
}

