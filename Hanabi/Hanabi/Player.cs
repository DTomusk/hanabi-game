namespace Hanabi;

public class Player
{
    public Board Board { get; init; }

    public Player(Board board)
    {
        Board = board;
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
            card.UpdateInformation(colour, value, moveNumber);
        }
    }
}