namespace Hanabi;

public class Player
{
    public Board Board { get; init; }
    public IList<CardInformation> CardInformation { get; private set; }

    public Player(Board board)
    {
        Board = board;
        CardInformation = new List<CardInformation>();
        foreach (var card in Board.Cards)
        {
            CardInformation.Add(new CardInformation(0));
        }
    }

    // Take all the information they can take into account 
    // Return the move they declare (the game will work out the consequences)
    public Move PlayMove(int informationTokens, int strikes, IList<Player> otherPlayers)
    {
        return new PlayCardMove(0);
    }
}

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