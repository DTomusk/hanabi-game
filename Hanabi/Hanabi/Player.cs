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

    public void UpdateInformation(CardColour? colour, int? value, int moveNumber)
    {
        for (int i = 0; i < Board.Cards.Count; i++)
        {
            var card = Board.Cards[i];
            var cardInfo = CardInformation[i];
            if (colour.HasValue && card.Colour == colour.Value)
            {
                cardInfo.SetColourInformation(colour.Value, moveNumber);
            }
            if (value.HasValue && card.Value == value.Value)
            {
                cardInfo.SetValueInformation(value.Value, moveNumber);
            }
        }
    }
}