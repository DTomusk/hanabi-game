namespace Hanabi;

public class Game
{
    public IList<Player> Players { get; private set; }
    public Center Center { get; private set; }
    public Deck Deck { get; private set; }
    public IList<Card> DiscardPile { get; private set; }
    public int InformationTokens { get; private set; }
    public int Strikes { get; private set; }
    public int TurnNumber { get; private set; }

    public const int MAX_INFORMATION_TOKENS = 8;
    public const int MAX_STRIKES = 3;

    // Initialise a new game with the given number of players
    public Game(int numberOfPlayers)
    {
        // Initialise shuffled deck
        Deck = new Deck();
        DiscardPile = new List<Card>();

        // Initialise boards and draw cards
        Players = new List<Player>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            var board = new Board();
            for (int j = 0; j < 5; j++)
            {
                var card = Deck.DrawCard();
                board.Cards.Add(card);
            }
            Players.Add(new Player(board));
        }

        InformationTokens = MAX_INFORMATION_TOKENS;
        Strikes = 0;
        TurnNumber = 0;

        Center = new Center();
    }

    public void Play()
    {
        // Game loop
        while (true)
        {
            TurnNumber++;
            foreach (var player in Players)
            {
                PrintGameState(player.Board);

                var move = player.PlayMove(InformationTokens, Strikes, Players.Where(p => p != player).ToList());

                switch (move)
                {
                    case PlayCardMove playMove:
                        HandlePlayMove(playMove, player.Board);
                        break;
                    case DiscardCardMove discardMove:
                        HandleDiscardMove(discardMove, player.Board);
                        break;
                    case GiveInformationMove informationMove:
                        HandleGiveInformationMove(informationMove);
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid move type {move.GetType()}");
                }

                if (Strikes >= MAX_STRIKES)
                {
                    Console.WriteLine("Game over! You have reached the maximum number of strikes.");
                    Console.WriteLine($"The total score for this game was {Center.GetScore()}");
                    return;
                }

                Console.WriteLine("Press a key to continue");
                Console.ReadLine();
            }
        }
    }

    private void PrintGameState(Board board)
    {
        board.Print();
        Console.WriteLine($"Number of information tokens: {InformationTokens}"); Console.WriteLine();
        Console.WriteLine($"Number of strikes: {Strikes}"); Console.WriteLine();
        Console.WriteLine($"Current score: {Center.GetScore()}"); Console.WriteLine(); Console.WriteLine();
    }

    // Attempt to play the given card to the center
    private void HandlePlayMove(PlayCardMove move, Board board)
    {
        var cardToPlay = ReplaceCard(board, move.CardIndex);

        var success = Center.PlayCard(cardToPlay);
        if (!success)
        {
            Strikes++;
            DiscardPile.Add(cardToPlay);
            Console.WriteLine($"Strike! Number of strikes: {Strikes}");
        }
    }

    private void HandleDiscardMove(DiscardCardMove move, Board board)
    {
        var cardToDiscard = ReplaceCard(board, move.CardIndex);
        DiscardPile.Add(cardToDiscard);
        if (InformationTokens < MAX_INFORMATION_TOKENS)
        {
            InformationTokens++;
        }
    }

    private void HandleGiveInformationMove(GiveInformationMove move)
    {
        Console.WriteLine("Giving information");
        var targetPlayer = Players[move.PlayerIndex];
        targetPlayer.UpdateInformation(move.Colour, move.Value, TurnNumber);
        InformationTokens--;
    }

    // Replace the card at the given index in the player's board with a new card from the deck
    // Return the card removed from that index
    private Card ReplaceCard(Board board, int cardIndex)
    {
        var cardToPlay = board.Cards[cardIndex];
        Console.WriteLine($"Playing card: {cardToPlay.Value} of {cardToPlay.Colour}");
        board.Cards.RemoveAt(cardIndex);

        if (Deck.Cards.Count > 0)
        {
            var newCard = Deck.DrawCard();
            board.Cards.Add(newCard);
        }

        return cardToPlay;
    }
}
