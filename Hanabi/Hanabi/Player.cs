namespace Hanabi;

public class Player
{
    public Guid Id { get; init; }
    public Board Board { get; init; }

    public Player(Board board)
    {
        Id = Guid.NewGuid();
        Board = board;
    }

    // Take all the information they can take into account 
    // Return the move they declare (the game will work out the consequences)
    public Move PlayMove(int informationTokens, int strikes, IList<Player> otherPlayers)
    {
        var randomNumber = 0;
        if (informationTokens == 0)
            randomNumber = new Random().Next(0, 2);
        else
            randomNumber = new Random().Next(0, 3);

        switch (randomNumber)
        {
            case 0:
                var cardIndex = new Random().Next(0, Board.Cards.Count);
                return new PlayCardMove(cardIndex);
            case 1:
                var discardIndex = new Random().Next(0, Board.Cards.Count);
                return new DiscardCardMove(discardIndex);
            case 2:
                var targetPlayerIndex = new Random().Next(0, otherPlayers.Count);
                var targetPlayer = otherPlayers[targetPlayerIndex];
                var informationType = new Random().Next(0, 2);
                switch (informationType)
                {
                    case 0:
                        var colour = targetPlayer.Board.Cards[new Random().Next(0, targetPlayer.Board.Cards.Count)].Colour;
                        return new GiveInformationMove(targetPlayer.Id, colour);
                    case 1:
                        var value = targetPlayer.Board.Cards[new Random().Next(0, targetPlayer.Board.Cards.Count)].Value;
                        return new GiveInformationMove(targetPlayer.Id, value);
                    default:
                        throw new InvalidOperationException("Invalid information type");
                }
            default:
                throw new Exception("Invalid random number");
        }
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