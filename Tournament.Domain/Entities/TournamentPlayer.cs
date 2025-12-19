
public class TournamentPlayer
{
    public Guid TournamentId { get; private set; }
    public Guid PlayerId { get; private set; }

    public int Points { get; private set; }
    public int Wins { get; private set; }
    public int Losses { get; private set; }
    public int Draws { get; private set; }

    protected TournamentPlayer() { }

    public TournamentPlayer(Guid tournamentId, Guid playerId)
    {
        TournamentId = tournamentId;
        PlayerId = playerId;
    }

    public void Win()
    {
        Wins++;
        Points += 3;
    }

    public void Draw()
    {
        Draws++;
        Points += 1;
    }

    public void Lose()
    {
        Losses++;
    }
}
