using Microsoft.AspNetCore.Mvc;
using Tournament.Application.Common;
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
        return Created("Criado com sucesso", ApiResponse<TournamentResponse>.Ok(
    TournamentMapper.ToResponse(tournament)
));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10)
    {
        var result = await getAllHandler.Handle(page, pageSize);

        return Ok(ApiResponse<PagedResponse<TournamentResponse>>.Ok(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await getByIdHandler.Handle(id);

        if (result is null)
            return NotFound(
                ApiResponse<string>.Fail("Tournament not found")
            );

        return Ok(ApiResponse<TournamentResponse>.Ok(result));
    }
}
