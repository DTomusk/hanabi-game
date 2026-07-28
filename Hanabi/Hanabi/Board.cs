namespace Hanabi;

public class Board
{
    public IList<Card> Cards { get; private set; }

    public Board()
    {
        Cards = new List<Card>();
    }

    public void Print()
    {
        Console.WriteLine("Board:");
        foreach (var card in Cards)
        {
            card.PrintCard();
        }
        Console.WriteLine();
    }
}
