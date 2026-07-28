namespace Hanabi;

public abstract record Move { }

public record PlayCardMove : Move
{
    public int CardIndex { get; private set; }
    public PlayCardMove(int cardIndex)
    {
        CardIndex = cardIndex;
    }
}

public record DiscardCardMove : Move
{
    public int CardIndex { get; private set; }
    public DiscardCardMove(int cardIndex)
    {
        CardIndex = cardIndex;
    }
}

public record GiveInformationMove : Move
{
    public Guid PlayerId { get; private set; }
    public CardColour? Colour { get; private set; }
    public int? Value { get; private set; }

    public GiveInformationMove(Guid playerId, CardColour colour)
    {
        PlayerId = playerId;
        Colour = colour;
        Value = null;
    }

    public GiveInformationMove(Guid playerId, int value)
    {
        PlayerId = playerId;
        Colour = null;
        Value = value;
    }
}