using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tournaments")]
public class TournamentsController : ControllerBase
{
    private readonly CreateTournamentHandler _handler;

    public TournamentsController(CreateTournamentHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTournamentCommand command)
    {
        var id = await _handler.Handle(command);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // depois a gente faz handler
        return Ok("Criado");
    }
}
