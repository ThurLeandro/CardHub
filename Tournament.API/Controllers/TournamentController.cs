using Microsoft.AspNetCore.Mvc;
using Tournament.Application.Tournaments.Create;
using Tournament.Application.Tournaments.GetAll;
using Tournament.Application.Tournaments.GetById;
using Tournament.Application.Tournaments.Responses;

[ApiController]
[Route("api/tournaments")]
public class TournamentsController(
    CreateTournamentHandler createHandler,
    GetAllTournamentsHandler getAllHandler,
    GetTournamentByIdHandler getByIdHandler
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTournamentCommand command)

    {
        var tournament = await createHandler.Handle(command);
        return Created("", TournamentMapper.ToResponse(tournament));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await getAllHandler.Handle());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await getByIdHandler.Handle(id);
        return result is null ? NotFound() : Ok(result);
    }
}
