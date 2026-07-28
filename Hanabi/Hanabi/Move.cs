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
    public int PlayerIndex { get; private set; }
    public CardColour? Colour { get; private set; }
    public int? Value { get; private set; }

    public GiveInformationMove(int playerIndex, CardColour colour)
    {
        PlayerIndex = playerIndex;
        Colour = colour;
        Value = null;
    }

    public GiveInformationMove(int playerIndex, int value)
    {
        PlayerIndex = playerIndex;
        Colour = null;
        Value = value;
    }
}