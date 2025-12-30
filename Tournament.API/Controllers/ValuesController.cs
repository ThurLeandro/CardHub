using Microsoft.AspNetCore.Mvc;
using Tournament.Application.Tournaments;
namespace Tournament.API.Controllers;


[ApiController]
[Route("api/tournaments")]
public class TournamentsController(CreateTournamentHandler handler) : ControllerBase
{
    private readonly CreateTournamentHandler _handler = handler;

    [HttpPost]
    public async Task<IActionResult> Create(CreateTournamentCommand command)
    {
        var id = await _handler.Handle(command);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok("Criado");
    }
}
