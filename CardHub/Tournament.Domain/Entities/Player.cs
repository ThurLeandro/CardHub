public class Player
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    protected Player() { }

    public Player(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
