using System.Runtime.InteropServices;

namespace Hanabi;

public class Deck
{
    public List<Card> Cards { get; private set; }

    public Deck()
    {
        Cards = new List<Card>();
        GenerateDeck();
        Shuffle();
    }

    public Card DrawCard()
    {
        if (Cards.Count == 0)
        {
            throw new InvalidOperationException("The deck is empty.");
        }
        var card = Cards[0];
        Cards.RemoveAt(0);
        return card;
    }

    private void GenerateDeck()
    {
        foreach (CardColour colour in Enum.GetValues(typeof(CardColour)))
        {
            for (int value = 1; value <= 5; value++)
            {
                int count = value == 1 ? 3 : (value == 5 ? 1 : 2);
                for (int i = 0; i < count; i++)
                {
                    Cards.Add(new Card(value, colour));
                }
            }
        }
    }

    private void Shuffle()
    {
        Random.Shared.Shuffle<Card>(CollectionsMarshal.AsSpan<Card>(Cards));
    }
}
