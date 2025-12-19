using APITornoument.sln.Tournament.Domain.Enums;

public class Tournament
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Game Game { get; private set; }
    public TournamentStatus Status { get; private set; }
    public int TotalRounds { get; private set; }

    private readonly List<TournamentPlayer> _players = new();
    public IReadOnlyCollection<TournamentPlayer> Players => _players;

    protected Tournament() { }

    public Tournament(string name, Game game, int totalRounds)
    {
        Id = Guid.NewGuid();
        Name = name;
        Game = game;
        TotalRounds = totalRounds;
        Status = TournamentStatus.Draft;
    }

    public void Start()
    {
        Status = TournamentStatus.Ongoing;
    }

    public void Finish()
    {
        Status = TournamentStatus.Finished;
    }
}
